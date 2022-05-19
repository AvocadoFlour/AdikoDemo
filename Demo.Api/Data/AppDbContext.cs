
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Data
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<Receiver> Receivers { get; set; }
        public virtual DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Demo;Trusted_Connection=True;Integrated Security = True;ApplicationIntent = ReadWrite;Encrypt = False;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Console.WriteLine("Planting seeds..");
            #region ReceiverSeed
            modelBuilder.Entity<Receiver>().HasData(new Receiver { Id = 4, NameSurname = "Ivan Horvat", Number = 53255352 });
            modelBuilder.Entity<Receiver>().HasData(new Receiver { Id = 1, NameSurname = "Petar Svačić", Number = 0973546653 });
            modelBuilder.Entity<Receiver>().HasData(new Receiver { Id = 2, NameSurname = "Marko Marulić", Number = 092875884 });
            modelBuilder.Entity<Receiver>().HasData(new Receiver { Id = 3, NameSurname = "Fran Krsto Frankopan", Number = 000346363 });
            #endregion
        }

    }
}
