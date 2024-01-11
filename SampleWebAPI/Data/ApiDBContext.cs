using Microsoft.EntityFrameworkCore;
using Models;

namespace SampleWebAPI.Data
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // If you need to remove the pluralisation of your table names enable below line.
            // modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<User>()
                .Property(e => e.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<User>()
                //.ToTable("Users") // Another way can define the table name here.
                .HasData(
                    new User
                    {
                        Aadhaar = "1234567890",
                        Address = "DummyAddress",
                        DateRegistered = "Today",
                        EMail = "muralidharan_it@hotmail.com",
                        Mobile = "9715286757",
                        Name = "Muralidharan",
                        Id = 1,
                        RoleId = 1
                    }
                );
        }
    }
}
