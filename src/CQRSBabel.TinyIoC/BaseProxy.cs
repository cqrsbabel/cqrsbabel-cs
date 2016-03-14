namespace CQRSBabel
{
    using System;
    using TinyMessenger;
    using System.Reflection;

    public abstract class BaseProxy : ITinyMessageProxy
    {
        protected static object _Instance;

        // might be overriden to deliver query message
        public virtual void Deliver(ITinyMessage message, ITinyMessageSubscription subscription)
        {
            try
            {
                ValidateMessage(message);
                subscription.Deliver(message);
            }
            catch (Exception ex)
            {
                string exceptionMethod = ExtractMethodName(subscription);
                throw new Exception(string.Format("Error in method {0}: {1}", exceptionMethod, ex.Message), ex);
            }
        }


        protected virtual void ValidateMessage(ITinyMessage message)
        {
            // might be overriden to validate message
        }

        protected static string ExtractMethodName(ITinyMessageSubscription subscription)
        {
            FieldInfo field = subscription.GetType().GetField("_DeliveryAction", BindingFlags.Instance | BindingFlags.NonPublic);
            var method = ((Delegate)field.GetValue(subscription)).Method;
            return method.ReflectedType.FullName.Replace("+", ".") + "." + method.Name;
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
    }
}
