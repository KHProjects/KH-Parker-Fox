using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Application.Messaging
{
    public interface INotifyClient
    {
        void Notify<T>(T @event);
    }
}
