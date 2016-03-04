namespace CQRSBabel
{
  public interface IQueryProxyCore
  {
    object Instance { get; }
  }
  public interface IQueryProxy
  {
    object Instance { get; }
  }
  public interface ICommandProxyCore
  {
    object Instance { get; }
  }
  public interface ICommandProxy
  {
    object Instance { get; }
  }
}