using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAsyncAwaitTest.Models
{
  public class Student
  {
    public int StudentID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public virtual ICollection<Enrolment> Enrolments { get; set; } 
  }
}