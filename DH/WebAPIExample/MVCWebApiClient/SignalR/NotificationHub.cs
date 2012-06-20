using System;
using System.Linq;
using SignalR.Hubs;

namespace MVCWebApiClient.SignalR
{
 public class NotificationHub : Hub
 {
  public string Activate()
  {
      return "Transaction Monitor Activated";
  }
 }
}