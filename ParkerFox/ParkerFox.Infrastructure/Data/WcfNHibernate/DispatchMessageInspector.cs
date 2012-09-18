using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace ParkerFox.Infrastructure.Data.WcfNHibernate
{
    public class DispatchMessageInspector : IDispatchMessageInspector
    {
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            //START SESSION
            return null;
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            //END SESSION
        }
    }
}
