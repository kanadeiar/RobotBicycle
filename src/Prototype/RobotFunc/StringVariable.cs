namespace Prototype.RobotFunc;

public class StringVariable(string name, string val = "")
{
    public string Name => name;

    public string Value
    {
        get => val;
        set => val = value;
    }
}