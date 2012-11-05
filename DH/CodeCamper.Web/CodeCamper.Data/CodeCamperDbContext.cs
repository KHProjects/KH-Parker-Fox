using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCamper.Data.Configuration;
using CodeCamper.Data.SampleData;
using CodeCamper.Model;

namespace CodeCamper.Data
{
  public class CodeCamperDbContext : DbContext
  {

    public CodeCamperDbContext() : base(nameOrConnectionString: "CodeCamper") { }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Session> Sessions { get; set; }


    //seed db:
    static CodeCamperDbContext()
    {
      Database.SetInitializer(new CodeCamperDatabaseInitializer());
    }


    //set / remove ef conventions and table configurations:
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

      //modelBuilder.Configurations.Add(new SessionConfiguration());
      //modelBuilder.Configurations.Add(new AttendanceConfiguration());
    }

  }
}
