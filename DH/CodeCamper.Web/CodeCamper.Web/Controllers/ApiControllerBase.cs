using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using CodeCamper.Data.Contracts;

namespace CodeCamper.Web.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {

      protected ICodeCamperUow Uow { get; set; }


    }
}
