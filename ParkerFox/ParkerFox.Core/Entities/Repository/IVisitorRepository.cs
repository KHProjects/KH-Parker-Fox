using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Repository
{
    public interface IVisitorRepository //: IRepository<Visitor>
    {
        void Save(Visitor visitor);
        IList<Visitor> GetRecent(int limit);

        //IList<Visitor> Query(ISpecification<Visitor>);
    }
}
