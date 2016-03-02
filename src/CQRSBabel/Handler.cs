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
      Token = hub.Subscribe<T>(Handle, (m) => m.Token == Token, Proxy.Instance);
    }

    public abstract void Handle(T message);
  }

  public abstract class CommandHandler<T> : IHandler where T : class, IRequest
  {
    public TinyMessageSubscriptionToken Token { get; set; }

    public CommandHandler()
    {
      var hub = IoC.Resolve<ITinyMessengerHub>();
      Token = hub.Subscribe<T>(Handle, (m) => m.Token == Token, ProxyTransaction.Instance);
    }

    public abstract void Handle(T message);
  }
}
