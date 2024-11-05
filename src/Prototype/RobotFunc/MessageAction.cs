namespace Prototype.RobotFunc;

public class MessageAction(string in1) : ActionBase
{
    private string _in1Value = string.Empty;

    private string In1 { get; } = in1;

    public override void Begin(Variables variables)
    {
        _in1Value = variables.ReadValue(In1);
    }

    public override void Run()
    {
        Console.WriteLine(_in1Value);
    }
}