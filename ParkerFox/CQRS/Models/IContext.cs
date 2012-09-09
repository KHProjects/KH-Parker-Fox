using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models
{
    public interface IContext
    {
        object this[object key] { get; set; }
    }
}