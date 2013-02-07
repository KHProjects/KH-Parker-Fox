using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS_ES.Models
{
    public class AccountInfo
    {
        public Guid AccountId { get; set; }
        public string Name { get; set; }
    }
}
