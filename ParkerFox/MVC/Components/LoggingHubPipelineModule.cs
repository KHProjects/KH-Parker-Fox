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
            Debug.WriteLine("signalr on before incoming" + context.MethodDescriptor.Name);
            return base.OnBeforeIncoming(context);
        }

        protected override object OnAfterIncoming(object result, IHubIncomingInvokerContext context)
        {
            Debug.WriteLine("OnAfterIncoming");
            return base.OnAfterIncoming(result, context);
        }

        protected override void OnAfterDisconnect(IHub hub)
        {
            Debug.WriteLine("OnAfterDisconnect");
            base.OnAfterDisconnect(hub);
        }

        protected override bool OnBeforeConnect(IHub hub)
        {
            Debug.WriteLine("OnBeforeConnect");
            return base.OnBeforeConnect(hub);
        }

        protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context)
        {
            Debug.WriteLine("OnBeforeOutgoing");
            return base.OnBeforeOutgoing(context);
        }

        protected override void OnAfterOutgoing(IHubOutgoingInvokerContext context)
        {
            Debug.WriteLine("OnAfterOutgoing");
            base.OnAfterOutgoing(context);
        }
        
    }
}