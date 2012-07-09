using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.CQRS
{
    public interface ICommandBus
    {
        void HandleCommand(ICommand command);
        void RunEvents(IAggregateRoot aggregateRoot);
        void HandleEvent(IEvent @event);
    }
}
