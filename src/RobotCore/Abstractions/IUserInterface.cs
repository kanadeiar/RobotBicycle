namespace RobotCore.Abstractions;

public interface IUserInterface
{
    string InMessage(string message, string title);

    void Message(string message, string title);
}