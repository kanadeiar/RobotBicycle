using System.Runtime.CompilerServices;
using RobotBicycle.Common.Abstractions;
using RobotBicycle.Common.Adapters;

[assembly: InternalsVisibleTo("RobotBicycleTests")]

namespace RobotBicycle.RobotModule;

public class Robot
{
    internal static IDialog dialog = new ConsoleDialogAdapter();
    
    private readonly IEnumerable<RobotAction> _program;
    
    public Robot(IEnumerable<RobotAction> program)
    {
        _program = program;
    }

    public bool Run()
    {
        foreach (var action in _program)
        {
            action.Run(dialog);
        }

        return true;
    }
}