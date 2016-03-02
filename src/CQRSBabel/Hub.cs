namespace CQRSBabel
{
  using TinyMessenger;

  public class Hub
  {
    public static object Publish<TMessage>(TMessage message) where TMessage : class, IRequest
    {
      IoC.Container.Resolve<ITinyMessengerHub>().Publish(message);
      return message.Response;
    }
  }
}
