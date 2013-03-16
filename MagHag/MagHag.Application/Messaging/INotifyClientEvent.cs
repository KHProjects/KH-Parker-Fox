using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Application.Messaging
{
    public interface INotifyClientEvent<T>
    {
        void Notify(T @event);
    }
}
