using MVC.Components;
using SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ConfigureSignalR();


        }

        public void Session_Start()
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsAuthenticationTicket formsAuthenticationTicket = new FormsAuthenticationTicket(1, "username",
                                                                                                    DateTime.Now,
                                                                                                    DateTime.Now.
                                                                                                        AddYears(10),
                                                                                                    true,
                                                                                                    Guid.NewGuid().
                                                                                                        ToString());

                string cookieData = FormsAuthentication.Encrypt(formsAuthenticationTicket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieData)
                    {
                        HttpOnly = true,
                        Expires = formsAuthenticationTicket.Expiration
                    };

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        private void ConfigureSignalR()
        {
            GlobalHost.DependencyResolver.Register(typeof (IConnectionIdGenerator),
                                                   () => new AuthenticationIdGenerator());
        }
    }
}