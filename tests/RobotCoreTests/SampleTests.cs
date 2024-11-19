using AutoFixture.Xunit2;
using Kanadeiar.Tests;
using Moq;

namespace RobotCoreTests;

public class SampleTests
{
    [Fact(DisplayName = "������ �������� �����")]
    public void TestSample()
    {
        true.Should().BeTrue();
    }

    [Theory(DisplayName = "������ ����� � ������������")]
    [AutoData]
    public void TestAutoData(Sample sample)
    {
        sample.Name.Should().NotBeNullOrEmpty();
    }

    [Theory(DisplayName = "������ ����� � ��������������")]
    [AutoMoqData]
    public void TestMock([Frozen] Mock<ISample> mock)
    {
        var sample = mock.Object;
        var actual = sample.Name;
        actual.Should().BeNull();
    }

    [Theory(DisplayName = "������ ����� � �������������� � ���������� ��������")]
    [InlineAutoData("test")]
    public void TestMock_WithSetValue(string expected, [Frozen] Mock<ISample> mock)
    {
        mock.SetupGet(x => x.Name).Returns(expected);
        var sample = mock.Object;
        var actual = sample.Name;
        actual.Should().Be(expected);
    }

    [Theory(DisplayName = "������ ����� � �������� ������������� ������")]
    [AutoMoqData]
    public void TestArrays_WhenAllClients(Sample[] samples, [Frozen] Mock<ISamplesRepository> mock)
    {
        mock.Setup(x => x.GetAll()).Returns(samples);
        var repository = mock.Object;

        var actuals = repository.GetAll();

        actuals.Count().Should().Be(samples.Length);
        actuals.Should().BeEquivalentTo(samples);
        mock.Verify(x => x.GetAll(), Times.Once);
    }

    [Fact(DisplayName = "������ �������� ������� ����������")]
    public void TestException()
    {
        var zero = 0;
        Action act = () => { var x = 4 / zero; };
        act.Should().Throw<DivideByZeroException>();
    }

    [Fact(DisplayName = "������ �������� ������ ������� ����������� �������")]
    public void TestEventInvoke()
    {
        var repository = new SampleRepository();
        using var monitor = repository.Monitor();

        repository.Execute();

        monitor.Should().Raise(nameof(ISamplesRepository.TestEvent))
            .WithSender(repository)
            .WithArgs<EventArgs>(a => a == EventArgs.Empty);
    }

    [Theory(DisplayName = "������ �������� ��������� ���������� �������")]
    [AutoMoqData]
    public void TestRaiseEvent([Frozen] Mock<ISamplesRepository> mock)
    {
        var isRaised = false;
        var repository = mock.Object;
        repository.TestEvent += (s, a) => isRaised = true;

        mock.Raise(x => x.TestEvent += null, null, EventArgs.Empty);

        isRaised.Should().BeTrue();
    }

    public interface ISample
    {
        string Name { get; set; }
    }

    public class Sample : ISample
    {
        public string Name { get; set; }
    }

    public interface ISamplesRepository
    {
        event EventHandler<EventArgs> TestEvent;
        IEnumerable<Sample> GetAll();
    }

    public class SampleRepository : ISamplesRepository
    {
        public event EventHandler<EventArgs> TestEvent;
        public IEnumerable<Sample> GetAll() => Array.Empty<Sample>();
        public void Execute() => TestEvent?.Invoke(this, EventArgs.Empty);
    }
}