using MagHag.Subscriptions.Core.Queries;
using MagHag.Subscriptions.Core.ReadModel;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MagHag.Subscriptions.Infrastructure.Queries
{
    public class PublicationQueries : IQueryPublications
    {
        public IEnumerable<ActivePublication> GetActive()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost:8181");

                using (var response = httpClient.GetAsync("publication").Result)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsAsync<IEnumerable<ActivePublication>>().Result;
                    }
                }
            }

            return new List<ActivePublication>();
        }
    }
}
