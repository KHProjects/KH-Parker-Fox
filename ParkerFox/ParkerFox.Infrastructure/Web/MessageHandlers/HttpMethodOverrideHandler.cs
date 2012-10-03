using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParkerFox.Infrastructure.Web.MessageHandlers
{
    /// <summary>
    /// http://www.asp.net/web-api/overview/working-with-http/http-message-handlers
    /// </summary>
    public class HttpMethodOverrideHandler : DelegatingHandler
    {
        private readonly string[] _methods = {"DELETE", "HEAD", "PUT"};
        private const string _header = "X-HTTP-Method-Override";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Post && request.Headers.Contains(_header))
            {
                var method = request.Headers.GetValues(_header).FirstOrDefault();
                if(_methods.Contains(method, StringComparer.InvariantCultureIgnoreCase))
                {
                    request.Method = new HttpMethod(method);
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}
