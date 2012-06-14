using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Data
{
    /// <summary>
    /// http://blog.tonywilliams.me.uk/unit-of-work-nhibnernate-and-asp-net-mvc/#irequeststate
    /// </summary>
    public interface IRequestState
    {
        T Get<T>(string key);
        void Store(string key, object something);
    }
}
