using AutoFixture.Xunit2;

namespace Kanadeiar.Tests;

public class InlineAutoMoqDataAttribute : InlineAutoDataAttribute
{
    public InlineAutoMoqDataAttribute(params object[] objects) 
        : base(new AutoMoqDataAttribute(), objects) { }
}