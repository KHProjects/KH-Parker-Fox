using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ParkerFox.Infrastructure.Data
{
    public class AspRequestState : IRequestState
    {
        public T Get<T>(string key)
        {
            return (T)HttpContext.Current.Items[key];
        }

        public void Store(string key, object something)
        {
            HttpContext.Current.Items[key] = something;
        }
    }
}
