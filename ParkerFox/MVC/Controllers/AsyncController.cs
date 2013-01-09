using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AsyncController : Controller
    {
        public async Task<ActionResult> Index()
        {
            return View();
        }

    }
}
