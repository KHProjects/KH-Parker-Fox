using ParkerFox.Core.Entities.Publication;

namespace ParkerFox.Core.ApplicationServices.Publication
{
    public interface ISubscriptionServices
    {
        Subscription GetCurrent();
    }
}
