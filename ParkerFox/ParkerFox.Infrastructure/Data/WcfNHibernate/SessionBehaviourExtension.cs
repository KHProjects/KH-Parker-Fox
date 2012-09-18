using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Data.WcfNHibernate
{
    public class SessionBehaviourExtension : BehaviorExtensionElement, IServiceBehavior
    {
        private DispatchMessageInspector _dispatchMessageInspector;

        public SessionBehaviourExtension()
        {
            _dispatchMessageInspector = new DispatchMessageInspector();
        }

        public override Type BehaviorType
        {
            get { return typeof (SessionBehaviourExtension); }
        }

        protected override object CreateBehavior()
        {
            return new SessionBehaviourExtension();
        }


        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach(ChannelDispatcher channelDispatcher in serviceHostBase.ChannelDispatchers)
            {
                foreach(EndpointDispatcher endpointDispatcher in channelDispatcher.Endpoints)
                {
                    endpointDispatcher.DispatchRuntime.MessageInspectors.Add(_dispatchMessageInspector);
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            
        }
    }
}
