using Xunit;
using CQRSBabel;

namespace CQRSBabelTests
{
  public class Class1
  {
    [Fact]
    public void PassingTest()
    {
      var test = new Class2();
      Assert.Equal(4, test.Add(2, 2));
    }

    [Fact]
    public void FailingTest()
    {
      var test = new Class2();
      Assert.Equal(5, test.Add(2, 2));
    }

    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(6)]
    public void MyFirstTheory(int value)
    {
      var test = new Class2();
      Assert.True(test.IsOdd(value));
    }
  }
}
