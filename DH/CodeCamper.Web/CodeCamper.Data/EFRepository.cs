using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Data.Contracts;

namespace CodeCamper.Data
{

  //The EF-dependant, generic repository for data access,
  //typeparam name="T" Type of entity for this Repository
  public class EFRepository<T> : IRepository<T> where T : class
  {

    public EFRepository(DbContext dbContext)
    {
      if (dbContext == null)
        throw new ArgumentNullException();

      DbContext = dbContext;
      DbSet = DbContext.Set<T>();
    }

    protected DbContext DbContext { get; set; }
    protected DbSet<T> DbSet { get; set; }

    public virtual IEnumerable<T> GetAll()
    {
      return DbSet;
    }

    public virtual T GetById(int id)
    {
      return DbSet.Find(id);
    }

    public virtual void Add(T entity)
    {
      DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
    }

    public virtual void Update(T entity)
    {
      DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
      if (dbEntityEntry.State == EntityState.Detached)
      {
        DbSet.Attach(entity);
      }
      dbEntityEntry.State = EntityState.Modified;

    }

    public void Delete(T entity)
    {
      DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
      if (dbEntityEntry.State != EntityState.Deleted)
      {
        dbEntityEntry.State = EntityState.Deleted;
      }
      else
      {
        DbSet.Attach(entity);
        DbSet.Remove(entity);
      }
    }

    public void Delete(int id)
    {
      var entity = GetById(id);
      if (entity == null) 
        return; // not found; assume already deleted
      Delete(entity);
    }
  }
}
