using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Core.Messaging
{
    public interface IApplicationBus
    {
        void Send<T>(T command);
        void Publish<T>(T @event);
    }
}
