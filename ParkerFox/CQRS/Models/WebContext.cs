using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models
{
    public class WebContext : IContext
    {
        public object this[object key]
        {
            get
            {
                return HttpContext.Current.Items[key];
            }
            set
            {
                HttpContext.Current.Items[key] = value;
            }
        }
    }
}