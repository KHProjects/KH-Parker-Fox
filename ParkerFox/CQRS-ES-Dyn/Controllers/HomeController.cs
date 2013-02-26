using CQRS_ES.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CQRS_ES.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Person person = new Person();           
            //Type personType = person.GetType();

            Type personType = Type.GetType("Person");
            var result = (AwesomeAttribute)personType.GetCustomAttributes<AwesomeAttribute>().First();
            if (result.IsAwesome)
            {
                //do something
            }

            var personInstance = Activator.CreateInstance(personType);

            List<MemberInfo> members = new List<MemberInfo>(personType.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance));

            var memberInfo = members.Single(_ => _.Name == "Secret");

            //((MethodBase)memberInfo).Invoke(person, null);
               
            return View(Configuration.Instance.Accounts);
        }

        [HttpPost]
        public ActionResult Index(RegisterAccountCommand registerAccountCommand)
        {
            Configuration.Instance.Bus.Handle(new RegisterAccountCommand
            {
                AccountId = Guid.NewGuid(),
                Balance = 100,
                Name = "Sebastian Kent"
            });

            return View(Configuration.Instance.Accounts);
        }

    }
}

[Awesome(true)]
public class Person
{
    public string FirstName { get; set; }

    public static int ThisIsBad = 10;

    public void SayYourname()
    {
        
    }

    private void Secret()
    {
        bool pass = true;
    }
}


public class AwesomeAttribute : Attribute
{
    private bool _isA;

    public AwesomeAttribute(bool isAwesome)
    {
        _isA = isAwesome;
    }

    public bool IsAwesome
    {
        get { return _isA; }
    }
}
