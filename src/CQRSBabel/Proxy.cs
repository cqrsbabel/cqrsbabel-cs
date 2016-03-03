namespace CQRSBabel
{
  using System;
  using TinyMessenger;
  using System.Reflection;

  public abstract class BaseProxy : ITinyMessageProxy
  {
    public abstract void Deliver(ITinyMessage message, ITinyMessageSubscription subscription);

    protected virtual void ValidateMessage(ITinyMessage message)
    {
      // might be overriden to validate message
    }

    protected static string ExtractMethodName(ITinyMessageSubscription subscription)
    {
      FieldInfo field = subscription.GetType().GetField("_DeliveryAction", BindingFlags.Instance | BindingFlags.NonPublic);
      var method = ((Delegate)field.GetValue(subscription)).Method;
      return method.ReflectedType.Name + "." + method.Name;
    }
  }

  public class QueryProxy : BaseProxy, IQueryProxyInternal
  {
    private static readonly QueryProxy _Instance = new QueryProxy();
    public ITinyMessageProxy Instance { get { return _Instance; } }

    public override void Deliver(ITinyMessage message, ITinyMessageSubscription subscription)
    {
      // might be overriden to deliver query message
      subscription.Deliver(message);
    }
  }

  public class CommandProxy : BaseProxy, ICommandProxyInternal
  {
    private static readonly CommandProxy _Instance = new CommandProxy();
    
    public ITinyMessageProxy Instance { get { return _Instance; } }

    public override void Deliver(ITinyMessage message, ITinyMessageSubscription subscription)
    {
      // might be overriden to deliver command message
      subscription.Deliver(message);
    }
  }
}
