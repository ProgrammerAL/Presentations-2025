using Shouldly;

namespace UnitTests;

public class UnitTest1
{
    [Theory]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(6)]
    public void WhenNumberEven_AssertIsValid(int number)
    {
        var result = IsEven(number);
        result.ShouldBeTrue();
    }

    private bool IsEven(int number)
    {
        return number % 2 == 0;
    }
}
