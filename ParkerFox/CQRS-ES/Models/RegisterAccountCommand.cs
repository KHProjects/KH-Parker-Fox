using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CQRS_ES.Models
{
    public class RegisterAccountCommand
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}