using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models
{
    public interface IEventBus
    {
        void Publish<T>(T @event) where T : IEvent;
    }
}