using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Model;

namespace CodeCamper.Data.Contracts
{
  public interface ISessionsRepository : IRepository<Session>
  {
    //IQueryable<SessionBrief> GetSessionBriefs();
    IEnumerable<SessionBrief> GetSessionBriefs();

  }
}
