using MVC.Components;
using SignalR;
using System.Web.Mvc;

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
            hubContext.Clients.messageFromServer(new {FirstName = "First Name"});
        }
    }
}
