namespace Prototype.RobotFunc;

public class InputTextAction(string message, string result) : ActionBase
{
    private string _message = string.Empty;

    private string Message { get; } = message;

    private string _resultValue = string.Empty;

    private string Result { get; } = result;

    public override void Begin(Variables variables)
    {
        _message = variables.ReadValue(Message);
    }

    public override void Run()
    {
        Console.WriteLine(_message);
        _resultValue = Console.ReadLine() ?? "";
    }

    public override void End(Variables variables)
    {
        variables.SetValue(Result, _resultValue);
    }
}