using System.Configuration;

namespace MagHag.Backend 
{
    using Ninject;
    using NServiceBus;
    using System.Data.SqlServerCe;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
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
                    .IsTransactional(true)
                    .PurgeOnStartup(false)
           .DisableTimeoutManager();
        }
    }
}