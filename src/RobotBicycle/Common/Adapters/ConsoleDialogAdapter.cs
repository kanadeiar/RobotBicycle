using RobotBicycle.Common.Abstractions;

namespace RobotBicycle.Common.Adapters;

public class ConsoleDialogAdapter : IDialog
{
    public void ShowDialog(string? value)
    {
        Console.WriteLine(value);
    }
}