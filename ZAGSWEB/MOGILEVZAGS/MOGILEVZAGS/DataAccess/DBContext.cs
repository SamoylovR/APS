using Microsoft.EntityFrameworkCore;
using MOGILEVZAGS.DataAccess.Models;

namespace MOGILEVZAGS.DataAccess
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserEntity>()
            //    .HasData(
            //    new UserEntity
            //    {
            //        Id = 1,
            //        UserName = "admin",
            //        Emal = "admin@admin.com",
            //        IsAdmin = true,
            //        DeliveryAdress = "none",
            //        PhoneNumber = "375(29)1111111"
            //    });

            modelBuilder.Entity<Client>()
                .HasData(
                new Client
                {
                    Id = 1,
                    Name = "admin",
                    Patronymic = "admin",
                    SecondName = "asdf",
                    Email = "asdf@asdfg.com",
                    Phone = "+3751233456",
                    Birthday = DateTime.Now,
                    CreatedAt = DateTime.Now,
                    TypeOfOperation = "None"
                });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Divorce> Divorсes { get; set; }

        public DbSet<Marriage> Marriages { get; set; }

        public DbSet<ContactForm> ContactForms { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Attendance> Attendances { get; set; }
    }

}
