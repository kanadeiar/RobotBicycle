namespace Prototype.RobotFunc;

public class ConcatAction(string in1, string in2, string result) : ActionBase
{
    private string _in1Value = string.Empty;

    private string In1 { get; } = in1;

    private string _in2Value = string.Empty;

    private string In2 { get; } = in2;

    private string _resultValue = string.Empty;

    private string Result { get; } = result;

    public override void Begin(Variables variables)
    {
        _in1Value = variables.ReadValue(In1);
        _in2Value = variables.ReadValue(In2);
    }

    public override void Run()
    {
        _resultValue = _in1Value + _in2Value;
    }

    public override void End(Variables variables)
    {
        variables.SetValue(Result, _resultValue);
    }
}