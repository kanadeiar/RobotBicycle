using FluentAssertions;
using Kanadeiar.Tests;
using Moq;
using RobotBicycle.Common.Abstractions;
using RobotBicycle.RobotModule;

namespace RobotBicycleTests.RobotModule;

public class RobotTests
{
    [Fact]
    public void TestRunRobot_ShouldSuccessRun()
    {
        var program = new[] { new RobotAction(string.Empty) };
        var robot = new Robot(program);

        var actual = robot.Run();

        actual.Should().BeTrue();
    }

    [Theory]
    [AutoMoqData]
    public void TestRunRobot_TestMessage(Mock<IDialog> dialog, string expected)
    {
        var program = new[] { new RobotAction(expected) };
        Robot.dialog = dialog.Object;
        var robot = new Robot(program);

        robot.Run();

        dialog.Verify(x => x.ShowDialog(expected), Times.Once);
    }
}