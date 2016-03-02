namespace CQRSBabel
{
  using TinyMessenger;
  using System;

  public interface IRequest : ITinyMessage
  {
    Guid Id { get; set; }
    TinyMessageSubscriptionToken Token { get; set; }
    object Response { get; set; }
  }

  public class Request<T> : IRequest where T : class
  {
    private readonly T handler;

    public Request()
    {
      handler = IoC.Resolve<T>();
      Id = Guid.NewGuid();
      Token = ((IHandler)handler).Token;
    }

    public Guid Id { get; set; }
    public TinyMessageSubscriptionToken Token { get; set; }

    public object Sender { get; private set; }
    public object Response { get; set; }
  }
}

