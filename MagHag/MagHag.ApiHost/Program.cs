using System.Web.Http;
using System.Web.Http.SelfHost;
using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Embedded;
using MagHag.ApiHost.Controllers;

namespace MagHag.ApiHost
{
    class Program
    {
        static void Main(string[] args)
        {
            IntializeDocumentStorage();
            Console.WriteLine("Document store initialized");
            InitializeApiHost();
            Console.WriteLine("Api Host initialized");
            Console.Read();
        }

        private static IDocumentStore _documentStore;
        private static HttpSelfHostServer _httpSelfHostServer;

        private static void IntializeDocumentStorage()
        {
            _documentStore = new EmbeddableDocumentStore
            {
                DataDirectory = "Data",
                UseEmbeddedHttpServer = true,
            };
            _documentStore.Initialize();
        }

        private static void InitializeApiHost()
        {
            //--Bug with controller locating http://forums.asp.net/post/4848156.aspx
            Type publicationController = typeof(PublicationController);
            _httpSelfHostServer = new HttpSelfHostServer(GetSelfHostConfiguration());
            _httpSelfHostServer.OpenAsync().Wait();
        }

        private static HttpSelfHostConfiguration GetSelfHostConfiguration()
        {
            var configuration = new HttpSelfHostConfiguration("http://localhost:8181");

            configuration.Routes.MapHttpRoute("Default", "{controller}/{id}", new { id = RouteParameter.Optional });

            return configuration;
        }

        public static IDocumentStore GetDocumentStore()
        {
            return _documentStore;
        }
    }
}
