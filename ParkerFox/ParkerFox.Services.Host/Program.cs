using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ParkerFox.Application.Services.Implementations;

namespace ParkerFox.Services.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(NewOrderProcessingService)))
            {
                serviceHost.Open();
                Console.WriteLine("Server listening...");
                Console.ReadLine();
            }
        }
    }
}
