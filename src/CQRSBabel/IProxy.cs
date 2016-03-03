using TinyMessenger;

namespace CQRSBabel
{
  interface IQueryProxyInternal : ITinyMessageProxy
  {
    ITinyMessageProxy Instance { get; }
  }
  public interface IQueryProxy : ITinyMessageProxy
  {
    ITinyMessageProxy Instance { get; }
  }
  interface ICommandProxyInternal : ITinyMessageProxy
  {
    ITinyMessageProxy Instance { get; }
  }
  public interface ICommandProxy : ITinyMessageProxy
  {
    ITinyMessageProxy Instance { get; }
  }
}