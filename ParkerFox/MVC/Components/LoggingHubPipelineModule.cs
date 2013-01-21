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
            return base.OnBeforeIncoming(context);
        }

        protected override object OnAfterIncoming(object result, IHubIncomingInvokerContext context)
        {
            return base.OnAfterIncoming(result, context);
        }

        protected override void OnAfterDisconnect(IHub hub)
        {
            base.OnAfterDisconnect(hub);
        }

        protected override bool OnBeforeConnect(IHub hub)
        {
            return base.OnBeforeConnect(hub);
        }

        protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context)
        {
            return base.OnBeforeOutgoing(context);
        }

        protected override void OnAfterOutgoing(IHubOutgoingInvokerContext context)
        {
            base.OnAfterOutgoing(context);
        }
        
    }
}