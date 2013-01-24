using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            MyMethod();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds / 1000);
            Console.ReadLine();
        }

        public static async void MyMethod()
        {
            var methodOne = MyLongRunningTaskOneAsync();
            var methodTwo = MyLongRunningTaskTwoAsync();

            Task.WaitAll(methodOne, methodTwo);
        }

        public static int MyLongRunningTaskOne()
        {
            Thread.Sleep(2000);
            return 1;
        }

        public static int MyLongRunningTaskTwo()
        {
            Thread.Sleep(2000);
            return 2;
        }

        public static async Task<int> MyLongRunningTaskOneAsync()
        {
            var result = await Task.Factory.StartNew(() => MyLongRunningTaskOne());
            return result;
        }

        public static async Task<int> MyLongRunningTaskTwoAsync()
        {
            var result = await Task.Factory.StartNew(() => MyLongRunningTaskTwo());
            return result;
        }
    }
}
