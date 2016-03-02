using System;
using TinyMessenger;

public class SubscriptionErrorHandler : ISubscriberErrorHandler
{
  public void Handle(ITinyMessage message, Exception exception)
  {
    throw exception;
  }
}
