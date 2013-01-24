using System.Web;
using System.Web.Mvc;
using MVC.Components;

namespace MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new MyApiActionFilter());
        }
    }
}