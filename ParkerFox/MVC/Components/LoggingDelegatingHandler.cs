using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MVC.Components
{
    /// <summary>
    /// http://www.asp.net/web-api/overview/working-with-http/http-message-handlers
    /// </summary>
    public class LoggingDelegatingHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Debug.WriteLine("processing: " + request.RequestUri.ToString());
            var response = await base.SendAsync(request, cancellationToken);
            Debug.WriteLine("completed: " + request.RequestUri.ToString());
            return response;
        }
    }
}