using RobotBicycle.Common.Abstractions;

namespace RobotBicycle.RobotModule;

public class RobotAction
{
    private readonly string _in1;

    public RobotAction(string in1)
    {
        _in1 = in1;
    }

    public void Run(IDialog dialog)
    {
        dialog.ShowDialog(_in1);
    }
}