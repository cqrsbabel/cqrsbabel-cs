using System;
using System.Collections.Generic;
using System.Linq;

namespace CQRSBabel
{
  // This project can output the Class library as a NuGet Package.
  // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
  public class Class2
  {
    public Class2()
    {
    }

    public bool IsOdd(int value)
    {
      return value % 2 == 1;
    }

    public int Add(int x, int y)
    {
      return x + y;
    }
  }
}
