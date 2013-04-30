using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagHag.Site.Components
{
    public class UserConnected
    {
        public UserConnected()
        {
            ConnectionIds = new HashSet<string>();
        }
        public string Name { get; set; }
        public HashSet<string> ConnectionIds { get; set; }
    }
}