using System.Net.Http.Headers;
using MagHag.Subscriptions.Core;
using MagHag.Subscriptions.Core.ReadModels;
using MagHag.Subscriptions.Messaging.Events;
using Newtonsoft.Json;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MagHag.Subscriptions.Application.Messaging.EventHandlers
{
    /// <summary>
    /// http://bliki.abdullin.com/event-sourcing/projections
    /// </summary>
    public class CreatedPublicationProjection : IHandleMessages<PublicationCreated>
    {
        public void Handle(PublicationCreated message)
        {
            Debug.WriteLine("CreatedPublicationProjection thread");
            //Console.WriteLine("CreatedPublicationProjection {0}", message.Name);
            var activePublication = new ActivePublication {Id = message.PublicationId, Title = message.Name};
            
            var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:8181")
                };
            
            HttpResponseMessage responseMessage;
            using (var content = new StringContent(JsonConvert.SerializeObject(activePublication)))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                responseMessage  = httpClient.PostAsync("publication", content).Result;
            }
        }
    }
}
