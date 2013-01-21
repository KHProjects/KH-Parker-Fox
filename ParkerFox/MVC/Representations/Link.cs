using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Representations
{
    public class Link
    {
        public Link(string name, string relation, Uri uri)
        {
            Name = name;
            Relation = relation;
            Uri = uri;
        }
        public string Name { get; private set; }
        public string Relation { get; private set; }
        public Uri Uri { get; private set; }
    }
}