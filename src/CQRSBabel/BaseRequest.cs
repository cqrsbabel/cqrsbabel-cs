namespace CQRSBabel
{
  using System;

  public abstract class BaseRequest<T> : IRequest where T : class
  {
    private readonly T handler;
    private readonly IIoC _container;

    public BaseRequest(IIoC container)
    {
      _container = container;
      handler = _container.Resolve<T>();
      Id = Guid.NewGuid();
      Token = ((IHandler)handler).Token;
    }

    public Guid Id { get; set; }
    public object Token { get; set; }

    public object Sender { get; private set; }
    public object Response { get; set; }
  }
}

