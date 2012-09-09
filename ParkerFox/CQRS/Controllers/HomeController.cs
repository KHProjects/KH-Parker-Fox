using CQRS.Models;
using CQRS.Models.Commands;
using CQRS.Models.Data;
using CQRS.Models.EventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CQRS.Models.Events;
using CQRS.Models.Entities;
using CQRS.Models.CommandHandlers;

namespace CQRS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var context = new WebContext();
            var eventStore = new SqlServerEventStore();
            var bookRepository = new EventSourcedRepository<Book>(eventStore, context);
            var createBookCommandHandler = new CreateBookCommandHandler(bookRepository);

            createBookCommandHandler.Handle(new CreateBook
                {
                    Title = "YOUR MOM, and other dogs"
                });

            new SqlServerPersistenceManager(context, eventStore).Commit();

            return View();
        }

    }
}
