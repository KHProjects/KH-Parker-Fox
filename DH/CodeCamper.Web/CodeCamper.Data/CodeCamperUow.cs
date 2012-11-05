using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Data.Contracts;
using CodeCamper.Data.Helpers;

namespace CodeCamper.Data
{
  public class CodeCamperUow : ICodeCamperUow, IDisposable
  {

    protected IRepositoryProvider RepositoryProvider { get; set; }
    private CodeCamperDbContext DbContext { get; set; }

    public CodeCamperUow(IRepositoryProvider repositoryProvider)
    {
      CreateDbContext();

      repositoryProvider.DbContext = DbContext;
      RepositoryProvider = repositoryProvider;
    }

    //repositories:
    //public IRepository<Room> Rooms { get { return GetStandardRepo<Rooms>(); } }
    //public IRepository<TimeSlot> TimeSlots { get { return GetStandardRepo<TimeSlots>(); } }
    //public IRepository<Track> Tracks { get { return GetStandardRepo<Tracks>(); } }
    public ISessionsRepository Sessions { get { return GetRepo<ISessionsRepository>(); } }
    public IPersonRepository PersonRepository { get { return GetRepo<IPersonRepository>(); } }
    //public IPersonsRepository Persons { get { return GetRepo<IPersonsRepository>(); } }
    //public IAttendanceRepository Attendance { get { return GetRepo<IAttendanceRepository>(); } } 


    //save pending changes to the database
    public void Commit()
    {
      DbContext.SaveChanges();
    }

    protected void CreateDbContext()
    {
      DbContext = new CodeCamperDbContext();

      // Do NOT enable proxied entities, else serialization fails
      DbContext.Configuration.ProxyCreationEnabled = false;

      // Load navigation properties explicitly (avoid serialization trouble)
      DbContext.Configuration.LazyLoadingEnabled = false;

      // Because Web API will perform validation, we don't need/want EF to do so
      DbContext.Configuration.ValidateOnSaveEnabled = false;

      //DbContext.Configuration.AutoDetectChangesEnabled = false;
      // We won't use this performance tweak because we don't need 
      // the extra performance and, when autodetect is false,
      // we'd have to be careful. We're not being that careful.
    }

    private IRepository<T> GetStandardRepo<T>() where T : class
    {
      return RepositoryProvider.GetRepositoryForEntityType<T>();
    }

    private T GetRepo<T>() where T : class
    {
      return RepositoryProvider.GetRepository<T>();
    }


    #region IDisposable

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (DbContext != null)
        {
          DbContext.Dispose();
        }
      }
    }

    #endregion

  }
}
