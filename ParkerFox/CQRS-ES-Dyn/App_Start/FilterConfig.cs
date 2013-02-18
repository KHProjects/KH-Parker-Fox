using System.Web;
using System.Web.Mvc;

namespace CQRS_ES_Dyn
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}