using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure
{
    public interface IBootStrapTask
    {
        int Priority { get; }
        void Execute();
    }
}
