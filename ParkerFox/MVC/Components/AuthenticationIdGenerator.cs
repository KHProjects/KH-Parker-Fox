using SignalR;
using System;
using System.Web.Security;

namespace MVC.Components
{
    /// <summary>
    /// use forms authentication to associate the same user context with any client connections through SignalR
    /// http://riba-escapades.blogspot.co.uk/2012/05/signalr-wire-up-connectionid-with-user.html 
    /// </summary>
    public class AuthenticationIdGenerator : IConnectionIdGenerator
    {
        public string GenerateConnectionId(IRequest request)
        {
            if(request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                var ticket = FormsAuthentication.Decrypt(request.Cookies[FormsAuthentication.FormsCookieName].Value);
                return ticket.UserData;
            }
            return new Guid().ToString();
        }
    }
}