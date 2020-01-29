using MovieRent.Entities;
using MovieRent.MAP.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRent.DAL
{
    public class ProjectContext:DbContext
    {
        public ProjectContext()
        {
            //this.Configuration.LazyLoadingEnabled = true;
            Database.Connection.ConnectionString = "server=MBTERYA017\\SQLSERVER;database=MovieDB;uid=sa;password=BkBk123!";

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdminMap());      
            modelBuilder.Configurations.Add(new CategoryMap());      
            modelBuilder.Configurations.Add(new MoviesMap());      
            modelBuilder.Configurations.Add(new PremiumMap());      
            modelBuilder.Configurations.Add(new UserAppMap());
            modelBuilder.Configurations.Add(new UserAppFilmListMap());
            modelBuilder.Configurations.Add(new SuppliersMap());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserApp> UserApps { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Premiums> Premiums { get; set; }
        public DbSet<UserAppFilmList> UserAppFilmLists { get; set; }
        public DbSet<Admin> Admins { get; set; }


    }
}
