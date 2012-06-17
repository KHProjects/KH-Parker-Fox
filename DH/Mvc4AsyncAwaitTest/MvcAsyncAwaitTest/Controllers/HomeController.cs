using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcAsyncAwaitTest.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

      //int answer1 = await CalculateAnswer1Async();
      //int answer2 = await CalculateAnswer2Async();
      Debug.WriteLine("before");
      //int answer1 = DoSomething1(); 
      //int answer2 = DoSomething2();
      DoDownload();
      Debug.WriteLine("after");

      //await DoSomething1Async();
      //await DoSomething2Async();
      //await DoSomething2Async();
      int i = 2;

      return View();
    }

    private async void DoDownload()
    {
      WebClient w = new WebClient();
      string txt = await w.DownloadStringTaskAsync("http://192.168.27.43/");
      await Task.Delay(2400);
      Debug.WriteLine("during");
    }


    //public async Task<int> DoSomething1()
    //{
    //  // In the Real World, we would actually do something...
    //  // For this example, we're just going to (asynchronously) wait 100ms.
    //  //await Task.Delay(100);
    //  //int answer1 = CalculateAnswer1();
    //  //int answer2 = await CalculateAnswer1();
    //
    //  //return answer1 + answer2;
    //}

    public async Task DoSomething2()
    {
      // In the Real World, we would actually do something...
      // For this example, we're just going to (asynchronously) wait 100ms.
      await Task.Delay(100);
    }



    public async Task<int> CalculateAnswer1()
    {
      await Task.Delay(6000); // (Probably should be longer...)

      // Return a type of "int", not "Task<int>"
      return 10;
    }

    public async Task<int> CalculateAnswer2Async()
    {
      await Task.Delay(100); // (Probably should be longer...)

      // Return a type of "int", not "Task<int>"
      return 55;
    }

  }
}
