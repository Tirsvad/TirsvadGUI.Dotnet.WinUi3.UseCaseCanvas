using System;
using System.Threading.Tasks;

namespace TirsvadGUI.ArtefactsGenerator.Mvvm.Input.Commands;

/// <summary>
/// Async-aware command surface used by view-models and source generators.
/// Mirrors the behavior expected by the existing AsyncRelayCommand implementation:
/// - supports async execution via <see cref="ExecuteAsync(object?)"/>
/// - supports fire-and-forget ICommand usage via <see cref="Execute(object?)"/>
/// - exposes CanExecute, CanExecuteChanged and a NotifyCanExecuteChanged helper
/// - exposes IsRunning and AllowConcurrentExecutions for reentrancy control
/// </summary>
public interface IAsyncRelayCommand
{
    /// <summary>
    /// When true the command allows concurrent executions; otherwise CanExecute returns false while command is running.
    /// </summary>
    bool AllowConcurrentExecutions { get; }

    /// <summary>
    /// True while the command is running.
    /// </summary>
    bool IsRunning { get; }

    /// <summary>
    /// Determines whether the command can execute with the given parameter.
    /// </summary>
    bool CanExecute(object? parameter);

    /// <summary>
    /// Executes the command in a fire-and-forget manner (suitable for ICommand).
    /// </summary>
    void Execute(object? parameter);

    /// <summary>
    /// Executes the command and returns a <see cref="Task"/> so callers can await completion.
    /// </summary>
    Task ExecuteAsync(object? parameter);

    /// <summary>
    /// Notifies listeners that the result of <see cref="CanExecute(object?)"/> may have changed.
    /// </summary>
    void NotifyCanExecuteChanged();

    /// <summary>
    /// Standard ICommand CanExecuteChanged event.
    /// </summary>
    event EventHandler? CanExecuteChanged;
}