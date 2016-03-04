namespace CQRSBabel
{
  using TinyIoC;
  using TinyMessenger;

  public abstract class QueryHandler<T> : IHandler where T : class, IRequestTinyIoC
  {
    public object Token { get; set; }

    public QueryHandler() : this(TinyIoCContainer.Current.Resolve<IIoC>()) { }

    public QueryHandler(IIoC container)
    {
      var hub = container.Resolve<ITinyMessengerHub>();

      IQueryProxy proxy;
      if (container.TryResolve(out proxy))
        Token = hub.Subscribe<T>(Handle, (m) => ((IRequest)m).Token == Token, proxy.Instance as ITinyMessageProxy);
      else
        Token = hub.Subscribe<T>(Handle, (m) => ((IRequest)m).Token == Token, container.Resolve<IQueryProxyCore>().Instance as ITinyMessageProxy);
    }

    public abstract void Handle(T message);
  }

  public abstract class CommandHandler<T> : IHandler where T : class, IRequestTinyIoC
  {
    public object Token { get; set; }

    public CommandHandler() : this(TinyIoCContainer.Current.Resolve<IIoC>()) { }

    public CommandHandler(IIoC IoC)
    {
      var hub = IoC.Resolve<ITinyMessengerHub>();

      ICommandProxy proxy;
      if (IoC.TryResolve(out proxy))
        Token = hub.Subscribe<T>(Handle, (m) => ((IRequest)m).Token == Token, proxy.Instance as ITinyMessageProxy);
      else
        Token = hub.Subscribe<T>(Handle, (m) => ((IRequest)m).Token == Token, IoC.Resolve<ICommandProxyCore>().Instance as ITinyMessageProxy);
    }

    public abstract void Handle(T message);
  }
}
