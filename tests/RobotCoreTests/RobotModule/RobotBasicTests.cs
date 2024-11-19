using Kanadeiar.Tests;
using Moq;
using RobotCore.Abstractions;
using RobotCore.RobotModule;

namespace RobotCoreTests.RobotModule;

/// <summary>
/// Базовые тесты робота
/// </summary>
public class RobotBasicTests
{
    [Theory]
    [AutoMoqData]
    public void TestExecute_ShouldSimpleMessage(Mock<IContext> mock, Mock<IUserInterface> mockUi, RobotProgram program)
    {
        mock.SetupGet(x => x.Ui).Returns(mockUi.Object);
        var robot = RobotBase.Create(mock.Object, program);
        
        robot.Execute();

        mockUi.Verify(x => x.Message("Робот запущен", It.IsAny<string>()), Times.Once);
    }

    [Theory]
    [AutoMoqData]
    public void TestCreate_ShouldLoadProgram(Mock<IContext> mock, RobotProgram expected)
    {
        var robot = RobotBase.Create(mock.Object, expected);

        var actual = robot.program;

        actual.Should().Be(expected);
    }
}