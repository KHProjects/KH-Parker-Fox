using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCamper.Data.Contracts
{
  public interface ICodeCamperUow
  {
    // Save pending changes to the data store.
    void Commit();

    // Repositories
    //IPersonsRepository Persons { get; }
    //IRepository<Room> Rooms { get; }
    IPersonRepository PersonRepository { get; }
    ISessionsRepository Sessions { get; }
    //IRepository<TimeSlot> TimeSlots { get; }
    //IRepository<Track> Tracks { get; }
    //IAttendanceRepository Attendance { get; }
  }
}
