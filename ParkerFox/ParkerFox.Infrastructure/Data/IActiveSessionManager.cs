using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace ParkerFox.Infrastructure.Data
{
    /// <summary>
    /// http://blog.tonywilliams.me.uk/unit-of-work-nhibnernate-and-asp-net-mvc/#iactivesessionmanager
    /// </summary>
    public interface IActiveSessionManager
    {
        ISession GetActiveSession();

        ///IUnitOfWork GetCurrentUnit();
    }
}
