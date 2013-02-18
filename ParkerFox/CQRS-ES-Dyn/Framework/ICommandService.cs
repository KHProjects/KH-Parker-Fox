using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_ES.Framework
{
    public interface ICommandService
    {
        void Handle(object command);
    }
}