using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Core.Entities
{
    public interface IRepository
    {
        void Save(Aggregate aggregate);
    }
}
