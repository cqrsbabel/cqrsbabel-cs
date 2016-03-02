namespace CQRSBabel
{
  using System;
  using TinyMessenger;
  using System.Reflection;

  public abstract class BaseProxy : ITinyMessageProxy
  {
    public abstract void Deliver(ITinyMessage message, ITinyMessageSubscription subscription);

    protected static void ValidateMessage(ITinyMessage message)
    {
      // must be overriden to validate message
    }

    protected static string ExtractMethodName(ITinyMessageSubscription subscription)
    {
      FieldInfo field = subscription.GetType().GetField("_DeliveryAction", BindingFlags.Instance | BindingFlags.NonPublic);
      var method = ((Delegate)field.GetValue(subscription)).Method;
      return method.ReflectedType.Name + "." + method.Name;
    }
  }

  public class Proxy : BaseProxy
  {
    private static readonly Proxy _Instance = new Proxy();
    public static ITinyMessageProxy Instance { get { return _Instance; } }

    public override void Deliver(ITinyMessage message, ITinyMessageSubscription subscription)
    {
      // must be overriden to deliver query message
    }
  }

  public class ProxyTransaction : BaseProxy
  {
    private static readonly ProxyTransaction _Instance = new ProxyTransaction();
    public static ITinyMessageProxy Instance { get { return _Instance; } }

    public override void Deliver(ITinyMessage message, ITinyMessageSubscription subscription)
    {
      // must be overriden to deliver command message
    }
  }
}
