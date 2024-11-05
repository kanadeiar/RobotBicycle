namespace Prototype.RobotFunc;

public class Variables(IEnumerable<StringVariable> variables)
{
    public string ReadValue(string name)
    {
        var val = variables.FirstOrDefault(v => v.Name == name);
        if (val != null)
        {
            return val.Value;
        }

        return name;
    }
    
    public void SetValue(string name, string variable)
    {
        var val = variables.FirstOrDefault(v => v.Name == name);
        if (val != null)
        {
            val.Value = variable;
        }
    }
}