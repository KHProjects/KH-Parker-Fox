using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAsyncAwaitTest.Models
{
  public class Course
  {
    public int CourseID { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
    public virtual ICollection<Enrolment> Enrolments { get; set; }

  }
}