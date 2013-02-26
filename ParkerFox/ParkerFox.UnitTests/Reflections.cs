using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ParkerFox.UnitTests
{
    [TestFixture]
    public class Reflections
    {
        [Test]
        public void Simples()
        {
            Person p = new Person();

            Type personType = p.GetType();

            List<MemberInfo> members = new List<MemberInfo>(personType.GetMembers());

            members.ForEach(_ => { Debug.WriteLine(_.Name); });

        }
    }

    public class Person
    {
        public string FirstName { get; set; }

        public void SayYourname()
        {
            Debug.WriteLine("My name is " + FirstName);
        }
    }
}
