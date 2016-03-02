namespace CQRSBabel
{
  using TinyIoC;

  public class IoC
  {
    private static bool autoRegistered;

    internal static TinyIoCContainer Container
    {
      get
      {
        var container = TinyIoCContainer.Current;
        if (!autoRegistered)
        {
          container.AutoRegister();
          autoRegistered = true;
        }

        return container;
      }
    }

    public static T Resolve<T>() where T : class
    {
      return Container.Resolve<T>();
    }
  }
}