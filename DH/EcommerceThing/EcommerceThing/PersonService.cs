using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceThing
{
    public interface IPersonService
    {
        IPersonService Process();
        IPersonService Process2();
    }

    public class PersonService : IPersonService
    {
        public PersonService(string init)
        {
            Console.Write(init);
        }

        public IPersonService Process()
        {
            Console.Write("process");
            return new AuditPersonService(this).Process();
            return this;
        }

        public IPersonService Process2()
        {
            Console.Write("process 2");
            return this;
        }
    }

    public class AuditPersonService : IPersonService
    {
        private IPersonService _personService;

        public AuditPersonService(IPersonService personService)
        {
            _personService = personService;
        }

        public IPersonService Process()
        {
            Console.WriteLine("u called pricess");
            _personService.Process();
            Console.WriteLine("u finished pricess");
        }

        public IPersonService Process2()
        {
            _personService.Process2();
        }
    }

}