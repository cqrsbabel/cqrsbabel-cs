namespace CQRSBabel
{
  using TinyMessenger;

  public class TinyIoCMessengerHub : IMessengerHub
  {
    private readonly IIoC _container;

    public TinyIoCMessengerHub(IIoC container)
    {
      _container = container;
    }

    public void Publish<TMessage>(TMessage message) where TMessage : class
    {
      var tinyMessage = message as ITinyMessage;
      _container.Resolve<ITinyMessengerHub>().Publish(tinyMessage);
    }
  }
}
