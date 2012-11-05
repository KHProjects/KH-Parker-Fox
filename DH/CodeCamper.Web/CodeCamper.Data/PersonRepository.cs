using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Data.Contracts;
using CodeCamper.Model;

namespace CodeCamper.Data
{
  public class PersonRepository : EFRepository<Person>, IPersonRepository
  {
        
    public PersonRepository(DbContext context) : base(context) { }

    public IEnumerable<Person> GetPeopleByFirstName()
    {
      return DbSet.Select(s => new Person
      {
        PersonId = s.PersonId,
        FirstName = s.FirstName,
        LastName = s.LastName,
        DateOfBirth = s.DateOfBirth
      });
    }

  }
}
