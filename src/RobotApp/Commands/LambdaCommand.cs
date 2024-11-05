﻿namespace RobotApp.Commands;

public class LambdaCommand(Action<object?>? execute, Func<object?, bool>? canExecute = null)
    : Base.Command
{
    private readonly Action<object?> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

    protected override bool CanExecute(object? p) => canExecute?.Invoke(p) ?? true;

    protected override void Execute(object? p) => _execute(p);
}