using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS.Models.Commands
{
    public class CreateBook : ICommand
    {
        public string Title { get; set; }
    }
}