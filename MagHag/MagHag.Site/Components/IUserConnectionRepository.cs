using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagHag.Site.Components
{
    public interface IUserConnectionRepository
    {
        UserConnected GetByUserName(string userName);
    }
}
