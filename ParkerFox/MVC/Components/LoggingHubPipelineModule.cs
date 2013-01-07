using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MVC.Components
{
    public class LoggingHubPipelineModule : HubPipelineModule
    {
        protected override void OnAfterConnect(IHub hub)
        {
            base.OnAfterConnect(hub);
        }

        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
        {
            Debug.WriteLine(context.MethodDescriptor.Name);
            return base.OnBeforeIncoming(context);
        }
        
    }
}