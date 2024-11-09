using RobotCore.Abstractions;

[assembly:InternalsVisibleTo("RobotCoreTests")]
namespace RobotCore.RobotModule;

public class RobotBase
{
    private IContext _context;

    public static RobotBase Create(IContext context)
    {
        var robot = new RobotBase();
        robot._context = context;

        return robot;
    }
    
    private RobotBase() { }

    public void Execute()
    {
        _context.Ui.Message("Робот запущен", "");
    }
}