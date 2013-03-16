using Ninject;
using Ninject.Syntax;

namespace MagHag.Application.Messaging
{
    public sealed class NotifyClient : INotifyClient
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NotifyClient(IResolutionRoot resolutionRoot)
        {
            _resolutionRoot = resolutionRoot;
        }

        public void Notify<T>(T @event)
        {
            var type = typeof (INotifyClientEvent<T>);
            var handler = _resolutionRoot.TryGet(type) as INotifyClientEvent<T>;
            if (handler != null)
            {
                handler.Notify(@event);
            }
        }
    }
}
