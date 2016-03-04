using TinyIoC;

namespace CQRSBabel
{
  public class Request<T> : BaseRequest<T>, IRequestTinyIoC where T : class, IHandler 
  {
    public Request() : base(TinyIoCContainer.Current.Resolve<IoC>())
    {
    }
  }
}
