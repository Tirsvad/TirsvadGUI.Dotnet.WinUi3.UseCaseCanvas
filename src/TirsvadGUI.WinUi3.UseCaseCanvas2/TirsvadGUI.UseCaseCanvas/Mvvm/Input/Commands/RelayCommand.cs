using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TirsvadGUI.ArtefactsGenerator.Mvvm.Input.Commands;

/// <summary>
/// Async-aware relay command implementation.
/// - Supports async handlers (Func<Task> / Func<object?, Task>)
/// - Accepts a CanExecute predicate (Func&lt;bool&gt; or Func&lt;object?, bool&gt;)
/// - Exposes IsRunning and AllowConcurrentExecutions to control reentrancy
/// - Optionally carries a CommandName (useful for generators or diagnostics)
/// </summary>
public sealed class RelayCommand : IAsyncRelayCommand, ICommand
{
    private readonly Func<object?, Task> _execute;
    private readonly Func<object?, bool>? _canExecute;
    private bool _isRunning;

    public string? CommandName { get; }

    public RelayCommand(Func<Task> execute, Func<bool>? canExecute = null, bool allowConcurrentExecutions = false, string? commandName = null)
        : this(_ => execute(), canExecute is null ? (Func<object?, bool>?)null : (_ => canExecute()), allowConcurrentExecutions, commandName)
    {
    }

    public RelayCommand(Action execute, Func<bool>? canExecute = null, bool allowConcurrentExecutions = false, string? commandName = null)
        : this(_ => { execute(); return Task.CompletedTask; }, canExecute is null ? (Func<object?, bool>?)null : (_ => canExecute()), allowConcurrentExecutions, commandName)
    {
    }

    public RelayCommand(Func<object?, Task> execute, Func<object?, bool>? canExecute = null, bool allowConcurrentExecutions = false, string? commandName = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
        AllowConcurrentExecutions = allowConcurrentExecutions;
        CommandName = commandName;
    }

    public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null, bool allowConcurrentExecutions = false, string? commandName = null)
        : this(parameter => { execute(parameter); return Task.CompletedTask; }, canExecute, allowConcurrentExecutions, commandName)
    {
    }

    public bool AllowConcurrentExecutions { get; }

    public bool IsRunning
    {
        get => _isRunning;
        private set
        {
            if (_isRunning == value) return;
            _isRunning = value;
            NotifyCanExecuteChanged();
        }
    }

    public bool CanExecute(object? parameter)
        => (AllowConcurrentExecutions || !IsRunning) && (_canExecute?.Invoke(parameter) ?? true);

    // ICommand implementation: fire-and-forget adapter
    public async void Execute(object? parameter)
    {
        // Fire-and-forget as required by ICommand signature.
        await ExecuteAsync(parameter).ConfigureAwait(false);
    }

    public async Task ExecuteAsync(object? parameter)
    {
        if (!CanExecute(parameter))
            return;

        try
        {
            IsRunning = true;
            await _execute(parameter).ConfigureAwait(false);
        }
        finally
        {
            IsRunning = false;
        }
    }

    public event EventHandler? CanExecuteChanged;

    public void NotifyCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    // Explicit interface mapping for ICommand (WPF/WinUI expect this signature)
    bool ICommand.CanExecute(object? parameter) => CanExecute(parameter);
    void ICommand.Execute(object? parameter) => Execute(parameter);
}