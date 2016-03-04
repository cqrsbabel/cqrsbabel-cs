namespace CQRSBabel
{
  using System;
  using TinyMessenger;
  using System.Reflection;

  public abstract class BaseProxy : ITinyMessageProxy
  {
    protected static object _Instance;

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

  public class QueryProxy : BaseProxy, IQueryProxyCore
  {
    public object Instance
    {
      get
      {
        if (_Instance == null)
          _Instance = new QueryProxy();

        return _Instance;
      }
    }

    public override void Deliver(ITinyMessage message, ITinyMessageSubscription subscription)
    {
      // might be overriden to deliver query message
      subscription.Deliver(message);
    }
  }

  public class CommandProxy : BaseProxy, ICommandProxyCore
  {
    public object Instance
    {
      get
      {
        if (_Instance == null)
          _Instance = new CommandProxy();

        return _Instance;
      }
    }

    public override void Deliver(ITinyMessage message, ITinyMessageSubscription subscription)
    {
      // might be overriden to deliver command message
      subscription.Deliver(message);
    }
  }
}
