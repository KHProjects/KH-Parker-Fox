using Microsoft.AspNet.SignalR;
using System;
using System.Web.Security;

namespace MVC.Components
{
    /// <summary>
    /// use forms authentication to associate the same user context with any client connections through SignalR
    /// </summary>
    public class AuthenticationIdGenerator : IConnectionIdPrefixGenerator
    {
        public string GenerateConnectionIdPrefix(IRequest request)
        {
            if (request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                var ticket = FormsAuthentication.Decrypt(request.Cookies[FormsAuthentication.FormsCookieName].Value);
                return ticket.UserData;
            }
            return new Guid().ToString();
        }
    }
}