using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Messaging.Commands
{
    public interface IHandleCommand<TCommand>
    {
        void Handle(TCommand command);
        //TResponse Process<TResponse>(TCommand command);
    }
}
