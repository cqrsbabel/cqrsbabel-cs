using Xunit;
using CQRSBabel;
using System;

namespace CQRSBabelTests
{
  public class Class1 : IDisposable
  {
    Class2 test;

    public Class1()
    {
      test = new Class2();
    }

    public void Dispose()
    {
      test = null;
    }

    [Fact]
    public void PassingTest()
    {
      Assert.Equal(4, test.Add(2, 2));
    }

    [Fact]
    public void AssertNotEqualTest()
    {
      Assert.NotEqual(5, test.Add(2, 2));
    }

    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(7)]
    public void MyFirstTheory(int value)
    {
      Assert.True(test.IsOdd(value));
    }
  }
}
