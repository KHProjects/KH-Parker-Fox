namespace MagHag.ReadStore 
{
    using Ninject;
    using NServiceBus;
using Raven.Client;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        
        public void Init()
        {
            Configure.With()
                .NinjectBuilder(new StandardKernel())
                .FileShareDataBus(@"\..\..\..\DataBusShare\")
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith("Commands"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith("Events"))
                //.DefiningCommandsAs(_ => _.GetType().Name.EndsWith("Command") && _.Namespace != null && _.Namespace.EndsWith("Commands"))
                //.DefiningEventsAs(_ => _.GetType().Name.EndsWith("Event") && _.Namespace != null && _.Namespace.EndsWith("Events"))
                .DefiningMessagesAs(t => t.Namespace == "Messages")
                .MsmqTransport()
                    .MsmqSubscriptionStorage()
                    .IsTransactional(false)
                    .PurgeOnStartup(false)
           .DisableTimeoutManager();
        }
    }
}