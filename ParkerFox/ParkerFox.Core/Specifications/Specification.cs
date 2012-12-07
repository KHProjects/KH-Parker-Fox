using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Core.Specifications
{
    public class Specification<T>
    {
        protected Expression<Func<T, bool>> _specficiation;

        public Expression<Func<T, bool>> IsSatisfiedBy()
        {
            return _specficiation;
        }
    }
}
