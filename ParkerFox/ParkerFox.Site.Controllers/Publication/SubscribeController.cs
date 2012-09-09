using ParkerFox.Application.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ParkerFox.Site.Controllers.Publication
{
    public class SubscribeController : Controller
    {
        public async Task<ActionResult> Index()
        {

            StoryService storyService = new StoryService();

            var stories = await storyService.GetByQuery("your mom");

            return View();
        }

        public ActionResult StepOne()
        {
            return PartialView();
        }
    }
}
