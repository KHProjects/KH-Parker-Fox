using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Representations
{
    public class Representation
    {
        protected IEnumerable<Link> Links { get; set; }

        public Link GetLinkByName(string name)
        {
            return Links.FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}