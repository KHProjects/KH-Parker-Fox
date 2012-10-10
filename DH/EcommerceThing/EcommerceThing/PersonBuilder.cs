using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceThing
{
    public class PersonBuilder
    {
        private Person _person = new Person();

        public Person Create()
        {
            return _person;
        }

        public PersonBuilder WithFirstName(string firstName)
        {
            _person.FirstName = firstName;
            return this;
        }

        public PersonBuilder WithActiveLoans(int loanCount)
        {
            for(int i =0;i<loanCount;i++)
            {
                _person.ListOfLoans += "loan " + i.ToString();
            }
            return this;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string ListOfLoans { get; set; }
    }
}