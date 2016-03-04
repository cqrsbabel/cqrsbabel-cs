namespace CQRSBabel
{
  using System.Web;
  using TinyIoC;
  using TinyMessenger;
  public class IoC : IIoC
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

          if (HttpContext.Current != null)
            container.Register<ITinyMessengerHub, TinyMessengerHub>().AsPerRequestSingleton();

          autoRegistered = true;
        }

        return container;
      }
    }

    public T Resolve<T>() where T : class
    {
      return Container.Resolve<T>();
    }

    public bool TryResolve<T>(out T resolvedType) where T : class
    {
      return Container.TryResolve<T>(out resolvedType);
    }
  }
}