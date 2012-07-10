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

            Asyncronous asynchrony = new Asyncronous();

            //asynchrony.RunPool();
            //asynchrony.RunEventBased();
            //asynchrony.RunTask();
            asynchrony.RunAsync();
            Console.Read();
        }
    }
}
