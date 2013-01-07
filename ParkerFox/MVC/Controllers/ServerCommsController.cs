using MVC.Components;

using System.Web.Mvc;
using Microsoft.AspNet.SignalR;

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
            hubContext.Clients.All.messageFromServer(new { FirstName = "First Name" });
        }
    }
}
