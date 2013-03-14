namespace MagHag.Backend 
{
    using NServiceBus;

    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With()
                .DefaultBuilder()
                .FileShareDataBus(@"\..\..\..\DataBusShare\")
                .DefiningCommandsAs(t => t.Namespace != null && t.Namespace.EndsWith("Commands"))
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.EndsWith("Events"))
                .DefiningMessagesAs(t => t.Namespace == "Messages")
                .MsmqTransport()
                    .MsmqSubscriptionStorage()
                    .IsTransactional(false)
                    .PurgeOnStartup(false)
           .DisableTimeoutManager();
        }
    }
}