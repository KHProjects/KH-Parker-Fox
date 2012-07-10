using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BitsNPerices;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //new FuckinWithThreads().Run();

            Asyncronous ascyrony = new Asyncronous();

            ascyrony.RunTask();

            Console.Read();
        }
    }
}
