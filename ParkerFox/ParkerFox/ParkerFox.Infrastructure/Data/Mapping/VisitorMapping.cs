using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using ParkerFox.Core.Entities;

namespace ParkerFox.Infrastructure.Data.Mapping
{
    public class VisitorMapping : ClassMap<Visitor>
    {
        public VisitorMapping()
        {
            Not.LazyLoad();
            Table("Visitor");
            Id(x => x.VisitorId).GeneratedBy.Native();
            Map(x => x.IpAddress);
            Map(x => x.LastVisit);
        }
    }
}
