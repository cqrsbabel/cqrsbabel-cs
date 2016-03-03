namespace CQRSBabel
{
  using TinyMessenger;

  public interface IHandler
  {
    TinyMessageSubscriptionToken Token { get; set; }
  }

  public abstract class QueryHandler<T> : IHandler where T : class, IRequest
  {
    public TinyMessageSubscriptionToken Token { get; set; }

    public QueryHandler()
    {
      var hub = IoC.Resolve<ITinyMessengerHub>();

      IQueryProxy proxy;
      if (IoC.TryResolve(out proxy))
        Token = hub.Subscribe<T>(Handle, (m) => m.Token == Token, proxy.Instance);
      else
        Token = hub.Subscribe<T>(Handle, (m) => m.Token == Token, IoC.Resolve<IQueryProxyInternal>().Instance);
    }

    public abstract void Handle(T message);
  }

  public abstract class CommandHandler<T> : IHandler where T : class, IRequest
  {
    public TinyMessageSubscriptionToken Token { get; set; }

    public CommandHandler()
    {
      var hub = IoC.Resolve<ITinyMessengerHub>();

      ICommandProxy proxy;
      if (IoC.TryResolve(out proxy))
        Token = hub.Subscribe<T>(Handle, (m) => m.Token == Token, proxy.Instance);
      else
        Token = hub.Subscribe<T>(Handle, (m) => m.Token == Token, IoC.Resolve<ICommandProxyInternal>().Instance);
    }

    public abstract void Handle(T message);
  }
}
