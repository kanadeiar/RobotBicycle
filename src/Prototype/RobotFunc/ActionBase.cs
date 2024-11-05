namespace Prototype.RobotFunc;

public abstract class ActionBase
{
    public virtual void Begin(Variables variables) { }

    public abstract void Run();

    public virtual void End(Variables variables) { }
}