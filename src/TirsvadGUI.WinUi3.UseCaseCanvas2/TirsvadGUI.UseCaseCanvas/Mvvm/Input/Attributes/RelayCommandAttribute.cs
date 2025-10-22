using System;

namespace TirsvadGUI.ArtefactsGenerator.Mvvm.Input.Attributes;

/// <summary>
/// Marks a method for source-generation (or manual wiring) of a relay command.
/// Supports optional explicit command name and an allow-concurrent-executions flag.
/// Use this when you want generator support for sync or non-async command methods.
/// For async-specific scenarios prefer <see cref="AsyncRelayCommandAttribute"/> (already present).
/// </summary>
[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
public sealed class RelayCommandAttribute : Attribute
{
    public RelayCommandAttribute() { }
    public RelayCommandAttribute(string commandName) => CommandName = commandName;
    public RelayCommandAttribute(bool allowConcurrentExecutions) => AllowConcurrentExecutions = allowConcurrentExecutions;
    public RelayCommandAttribute(string commandName, bool allowConcurrentExecutions)
    {
        CommandName = commandName;
        AllowConcurrentExecutions = allowConcurrentExecutions;
    }

    /// <summary>
    /// Optional explicit name for the generated command property. If null, a name will be derived from the method name.
    /// </summary>
    public string? CommandName { get; }

    public string? CanExecute { get; }

    /// <summary>
    /// When true the generated command will allow concurrent executions; otherwise it will block reentrancy while running.
    /// Defaults to false.
    /// </summary>
    public bool AllowConcurrentExecutions { get; }

}