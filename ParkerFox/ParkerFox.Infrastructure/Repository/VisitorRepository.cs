using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Core.Entities;
using ParkerFox.Core.Entities.Repository;
using ParkerFox.Infrastructure.Data;
using FluentNHibernate;
using NHibernate;

namespace ParkerFox.Infrastructure.Repository
{
    public sealed class VisitorRepository : IVisitorRepository
    {

        public void Save(Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public IList<Visitor> GetRecent(int limit)
        {
            throw new NotImplementedException();
        }
    }
}
