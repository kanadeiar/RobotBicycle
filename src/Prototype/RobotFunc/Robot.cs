namespace Prototype.RobotFunc;

public class Robot(IEnumerable<StringVariable> variables, IEnumerable<ActionBase> program)
{
    public void Run()
    {
        var vars = new Variables(variables);

        foreach (var action in program)
        {
            action.Begin(vars);

            action.Run();

            action.End(vars);
        }
    }
}