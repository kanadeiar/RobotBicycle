using System.Collections;
using AutoFixture.Xunit2;
using FluentAssertions;
using Kanadeiar.Tests;
using Moq;

namespace RobotBicycleTests;

public class SampleTests
{
    [Fact(DisplayName = "Простой тест логического значения")]
    public void Test1()
    {
        true.Should().BeTrue();
    }

    [Theory(DisplayName = "Простой тест с автоматическими данными")]
    [AutoData]
    public void TestAuto(string name)
    {
        name.Should().NotBeNullOrEmpty();
    }

    [Theory(DisplayName = "Тест с автомоком"), AutoMoqData]
    public void TestMethod1([Frozen] Mock<IPerson> mock, Person person)
    {
        mock.SetupGet(x => x.Name).Returns(person.Name);
        
        var actual = mock.Object;
        
        actual.Name.Should().Be(person.Name);
    }

    [Theory(DisplayName = "Тест с линейными значениями и с автоматическими данными")]
    [InlineAutoMoqData(3, 3)]
    public void TestValues(int value, int expected, Person person)
    {
        person.Name.Should().NotBeNullOrEmpty();

        value.Should().Be(expected);
    }

    [Theory(DisplayName = "Тест с линейными данными")]
    [InlineData(true)]
    [InlineData("One")]
    public void Inline(object value)
    {
        value.Should().NotBeNull();
    }

    [Theory, MemberData(nameof(GetTestData))]
    public void Method(int digital)
    {
        digital.Should().Be(1);
    }
    public static IEnumerable<object[]> GetTestData()
    {
        return new List<object[]>
        {
            new object[] { 1 }
        };
    }

    [Theory, MemberData(nameof(DataForTest))]
    public void GenericMethod(int one, int two)
    {
        one.Should().Be(two);
    }
    public static TheoryData<int, int> DataForTest = new TheoryData<int, int>
    {
        { 1, 1 }
    };

    [Theory, ClassData(typeof(TestData))]
    public void ClassStandard(int value)
    {
        value.Should().Be(1);
    }
    private class TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return [1];
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    [Theory, MemberData(nameof(DataSource.TestData), 1, MemberType = typeof(DataSource))]
    public void ClassSource(int value)
    {
        value.Should().Be(1);
    }
    private static class DataSource
    {
        private static readonly List<object[]> _data = new()
        {
            new object[] { 1 },
        };

        public static IEnumerable<object[]> TestData(int one)
        {
            return _data;
        }
    }

    [Theory, MemberData(nameof(TestData2), parameters: [new object[] { "1" }])]
    public void TypesTestData(string s, bool expected)
    {
        int.TryParse(s, out _).Should().Be(expected);
    }
    public static TheoryData<string, bool> TestData2(object[] args)
    {
        return new TheoryData<string, bool>
        {
            { $"{args[0]}", true },
            { $"{args[0]}a", false },
        };
    }

    public interface IPerson
    {
        string Name { get; set; }
    }

    public class Person : IPerson
    {
        public string Name { get; set; }
    }
}