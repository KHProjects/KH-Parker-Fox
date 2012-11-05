using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Model;

namespace CodeCamper.Data.SampleData
{
  public class CodeCamperDatabaseInitializer :
    //CreateDatabaseIfNotExists<CodeCamperDbContext>
    DropCreateDatabaseIfModelChanges<CodeCamperDbContext>
  {

    protected override void Seed(CodeCamperDbContext context)
    {
      //seed code here:

      //var SessionBrief = AddSessions(context);

      //Session Test DB Data
      var session = new List<Session>
      {
          new Session { Title="Session1", RoomId=1, Code="Code1", SpeakerId=1, TimeSlotId=1, TrackId=1, Tags="", Level="5", Id=1 },
          new Session { Title="Session2", RoomId=2, Code="Code2", SpeakerId=2, TimeSlotId=2, TrackId=2, Tags="c#|asp.net|ef", Level="5", Id=2},
      };
      session.ForEach(s => context.Sessions.Add(s));


      //Person Test DB Data
      var person = new List<Person>
      {
          new Person { FirstName="TestFirstName1", LastName="TestLastName1" },
          new Person { FirstName="TestFirstName2", LastName="TestLastName2" },
      };
      person.ForEach(s => context.Persons.Add(s));





      context.SaveChanges();

    }





    //private List<Session> AddSessions(CodeCamperDbContext context)
    //{
    //  // Total number of rooms = (number of tracks) + (number of TheChosen people); see note in TheChosen.
    //  var names = new[] { 
    //            // 'Track' rooms (10 in use)
    //            "Surf A", "Surf B", "Mendocino A", "Mendocino B", "Mendocino C", 
    //            "Stromboli", "Chico", "Frisco", "Miami", "Boston",
    //            "Venice", "Rome", "Paris", "Madrid", "London",
    //            // 'TheChosen' rooms (13 in use)
    //            "Levenworth", "Pelham Bay", "San Quentin", "Alcatraz", "Folsom",
    //            "Aqueduct", "Saratoga", "Golden Gate", "Santa Anita", "Monmouth Park", 
    //            "Ossining", "Danbury", "Allenwood", "Lompoc", "La Tuna",
    //            "Caliente", "Churchill Downs", "Calder", "Del Mar","Hollywood Park"
    //        };
    //  var rooms = new List<Room>();
    //  Array.ForEach(names, name =>
    //  {
    //    var item = new Room { Name = name };
    //    rooms.Add(item);
    //    context.Rooms.Add(item);
    //  });
    //  context.SaveChanges();
    //  return rooms;
    //}


  }
}
