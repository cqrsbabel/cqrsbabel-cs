namespace CQRSBabel
{
  public interface IMessengerHub
  {
    void Publish<TMessage>(TMessage message) where TMessage : class;
  }
}