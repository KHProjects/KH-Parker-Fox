using ParkerFox.WebApi.Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace ParkerFox.WebApi.Host
{
    class Program
    {        
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8181");

            config.Routes.MapHttpRoute("Default", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            //--Bug with controller locating http://forums.asp.net/post/4848156.aspx

            Type productController = typeof(ProductController);
 
            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Web Api Server Ready....");
                Console.ReadLine();
            }
        }
    }
}
