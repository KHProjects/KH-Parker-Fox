using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models
{
    public interface IHandleEvent<T> where T: IEvent
    {
        void Handle(T @event);
    }
}