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
    public void TestExecute_ShouldSimpleMessage(Mock<IContext> mock, Mock<IUserInterface> mockUi)
    {
        mock.SetupGet(x => x.Ui).Returns(mockUi.Object);
        var robot = RobotBase.Create(mock.Object);
        
        robot.Execute();

        mockUi.Verify(x => x.Message("Робот запущен", It.IsAny<string>()), Times.Once);
    }
}