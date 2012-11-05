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
  public class SessionsRepository : EFRepository<Session>, ISessionsRepository
  {

    public SessionsRepository(DbContext context) : base(context) { }

    public IEnumerable<SessionBrief> GetSessionBriefs()
    {
      return DbSet.Select(s => new SessionBrief
      {
        Id = s.Id,
        Title = s.Title,
        Code = s.Code,
        SpeakerId = s.SpeakerId,
        TrackId = s.TrackId,
        TimeSlotId = s.TimeSlotId,
        RoomId = s.RoomId,
        Level = s.Level,
        Tags = s.Tags,
      });
    }

  }
}
