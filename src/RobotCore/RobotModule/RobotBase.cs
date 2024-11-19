using RobotCore.Abstractions;

[assembly:InternalsVisibleTo("RobotCoreTests")]
namespace RobotCore.RobotModule;

public class RobotBase
{
    private IContext _context;
    internal RobotProgram program;

    public static RobotBase Create(IContext context, RobotProgram program)
    {
        var robot = new RobotBase();
        robot._context = context;
        robot.program = program;

        return robot;
    }
    
    private RobotBase() { }

    public void Execute()
    {
        _context.Ui.Message("Робот запущен", "");
    }
}