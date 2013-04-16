using System.Web.Http;
using Raven.Client;
using System;
using Raven.Client.Embedded;
using System.Web.Http.SelfHost;
using Ninject;

namespace MagHag.ReadStore
{
    class Program
    {
        private static Program instance;
        private IDocumentStore _documentStore;
        private HttpSelfHostServer _httpHost;
        private IKernel _kernel;

        static void Main(string[] args)
        {
            instance = new Program().Setup();
            Console.WriteLine("Read store initialized. Press any key to exit");
            Console.Read();
        }

        public Program Setup()
        {
            _kernel = new StandardKernel();

            //_documentStore = new EmbeddableDocumentStore
            //    {
            //        UseEmbeddedHttpServer = true,
            //        DataDirectory = "data"
            //    };
            //_documentStore.Initialize();

            //_kernel.Bind<IDocumentStore>().ToMethod(_ =>
            //    {
            //        var documentStore = new EmbeddableDocumentStore
            //            {
            //                UseEmbeddedHttpServer = true,
            //                DataDirectory = "ReadStore"
            //            };
            //        documentStore.Initialize();
            //        return documentStore;
            //    }).InSingletonScope();

            _httpHost = new HttpSelfHostServer(GetSelfHostConfiguration());
            _httpHost.OpenAsync().Wait();

            return this;
        }

        private HttpSelfHostConfiguration GetSelfHostConfiguration()
        {
            var configuration = new HttpSelfHostConfiguration("http://localhost:8181");

            configuration.Routes.MapHttpRoute("Default", "{controller}/{id}", new { id = RouteParameter.Optional });
            
            configuration.DependencyResolver = new NinjectHttpDependencyResolver(_kernel);

            return configuration;
        }
    }
}
