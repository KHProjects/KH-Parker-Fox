
using System.Data.SqlClient;
using MVC.Components;

using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using System.Configuration;

namespace MVC.Controllers
{
    public class ServerCommsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void SendBackMessage()
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<SignalRHub>();
            hubContext.Clients.All.receiveData(new { FirstName = "First Name" });
        }
    }
}
