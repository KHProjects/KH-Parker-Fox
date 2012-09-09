using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models
{
    public interface IHandleCommand<T> where T : ICommand
    {
        void Handle(T command);
    }
}