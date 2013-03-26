using MagHag.Subscriptions.Core.Queries;
using MagHag.Subscriptions.Core.ReadModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Subscriptions.Infrastructure.Queries
{
    public class PublicationQueries : IQueryPublications
    {
        public IEnumerable<ActivePublication> GetActive()
        {
            return new List<ActivePublication>
                {
                    new ActivePublication{Id = Guid.NewGuid(), Title = "Disposing of the bodies of your minions"}
                };
        }
    }
}
