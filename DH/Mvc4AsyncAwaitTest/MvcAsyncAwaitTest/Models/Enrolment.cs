using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAsyncAwaitTest.Models
{
  public class Enrolment
  {
    public int EnrolmentID { get; set; }
    public int StudentID { get; set; }
    public int CourseID { get; set; }
    public DateTime EnrolmentDate { get; set; }
    public decimal? Grade { get; set; }
    public virtual Student Student { get; set; }
    public virtual Course Course { get; set; }

  }
}