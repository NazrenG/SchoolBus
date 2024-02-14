using Microsoft.EntityFrameworkCore;
using SchoolBus_Model.Entities.Concretes;
using System.Reflection;

namespace SchoolBus_Access.Context
{
    public class SchoolBus_Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolBus2;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
            optionsBuilder.UseSqlServer(conStr)
                .UseLazyLoadingProxies();
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Bus> Buses { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
    }
}
