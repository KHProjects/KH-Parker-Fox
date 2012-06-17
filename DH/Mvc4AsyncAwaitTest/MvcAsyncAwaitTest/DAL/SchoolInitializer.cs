using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MvcAsyncAwaitTest.Models;

namespace MvcAsyncAwaitTest.DAL
{
  public class SchoolInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
  {
    protected override void Seed(SchoolContext context)
    {
      //Student Test DB Data
      var students = new List<Student>
      {
          new Student { FirstName = "Carson", LastName = "Alexander" },
          new Student { FirstName = "Meredith", LastName = "Alonso" },
          new Student { FirstName = "Arturo", LastName = "Anand" },
          new Student { FirstName = "Gytis", LastName = "Barzdukas" },
          new Student { FirstName = "Yan", LastName = "Li" },
          new Student { FirstName = "Peggy", LastName = "Justice" },
          new Student { FirstName = "Laura", LastName = "Norman" },
          new Student { FirstName = "Nino", LastName = "Olivetto" }
      };
      students.ForEach(s => context.Students.Add(s));
      context.SaveChanges();

      var courses = new List<Course>
      {
        new Course { Title = "Chemistry", Credits = 3 },
        new Course { Title = "Microeconomics", Credits = 3 },
        new Course { Title = "Science", Credits = 3 },
        new Course { Title = "Calculus", Credits = 4 },
        new Course { Title = "Trigonometry", Credits = 4 },
        new Course { Title = "Composition", Credits = 3 },
        new Course { Title = "Literature", Credits = 4 }
      };
      courses.ForEach(s => context.Courses.Add(s));
      context.SaveChanges();

      var enrolments = new List<Enrolment>
      {
        new Enrolment { StudentID = 1, CourseID = 1, EnrolmentDate = DateTime.Parse("01/01/2011"), Grade = 1 },
        new Enrolment { StudentID = 1, CourseID = 3, EnrolmentDate = DateTime.Parse("01/09/2010"), Grade = 1 },
        new Enrolment { StudentID = 1, CourseID = 2, EnrolmentDate = DateTime.Parse("01/09/2010"), Grade = 3 },
        new Enrolment { StudentID = 2, CourseID = 4, EnrolmentDate = DateTime.Parse("01/09/2010"), Grade = 2 },
        new Enrolment { StudentID = 2, CourseID = 5, EnrolmentDate = DateTime.Parse("01/09/2010"), Grade = 4 },
        new Enrolment { StudentID = 2, CourseID = 6, EnrolmentDate = DateTime.Parse("01/09/2010"), Grade = 4 },
        new Enrolment { StudentID = 3, CourseID = 1, EnrolmentDate = DateTime.Parse("01/09/2010") },
        new Enrolment { StudentID = 4, CourseID = 1, EnrolmentDate = DateTime.Parse("01/09/2010") },
        new Enrolment { StudentID = 4, CourseID = 2, EnrolmentDate = DateTime.Parse("01/09/2010"), Grade = 4 },
        new Enrolment { StudentID = 5, CourseID = 3, EnrolmentDate = DateTime.Parse("01/09/2010"), Grade = 3 },
        new Enrolment { StudentID = 6, CourseID = 4, EnrolmentDate = DateTime.Parse("01/09/2010"),  },
        new Enrolment { StudentID = 7, CourseID = 5, EnrolmentDate = DateTime.Parse("01/09/2010"), Grade = 2 }
      };
      enrolments.ForEach(s => context.Enrolments.Add(s));
      context.SaveChanges();
    }//end of Seed
  }//end of SchoolInitializer
}