using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AsyncController : Controller
    {
        public async Task<ActionResult> Index()
        {
            //await Task.Factory.StartNew(() => Thread.Sleep(TimeSpan.FromSeconds(2)));
            MyMethod();

            return View();
        }

        //public  ActionResult Index()
        //{
        //    MyMethod();

        //    return View();
        //}

        public async void MyMethod()
        {
            var methodOne = MyLongRunningTaskOneAsync();
            var methodTwo = MyLongRunningTaskTwoAsync();

            Debug.WriteLine("mymethod");

            await Task.WhenAll(methodOne, methodTwo);
        }

        public int MyLongRunningTaskOne()
        {
            Debug.WriteLine("MyLongRunningTaskOne");
            Thread.Sleep(4000);
            return 1;
        }

        public int MyLongRunningTaskTwo()
        {
            Debug.WriteLine("MyLongRunningTaskTwo");
            Thread.Sleep(4000);
            return 2;
        }

        public async Task<int> MyLongRunningTaskOneAsync()
        {
            Debug.WriteLine("MyLongRunningTaskOneAsync");
            var result = await Task.Factory.StartNew(() => MyLongRunningTaskOne());
            return result;
        }

        public async Task<int> MyLongRunningTaskTwoAsync()
        {
            Debug.WriteLine("MyLongRunningTaskTwoAsync");
            var result = await Task.Factory.StartNew(() => MyLongRunningTaskTwo());
            return result;
        }
    }
}
