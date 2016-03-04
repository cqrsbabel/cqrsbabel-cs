namespace CQRSBabel
{
  public class MessengerHub
  {
    private readonly IMessengerHub _hub;

    public MessengerHub(IMessengerHub hub)
    {
      _hub = hub;
    }

    public object Publish<TMessage>(TMessage message) where TMessage : class, IRequest
    {
      _hub.Publish(message);
      return message.Response;
    }
  }
}
