using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Entities.Repository
{
    public interface IEntitySet<T>
    {
        IEnumerable<T> Page(int index, int size);
        IEnumerable<T> All();
    }
}
