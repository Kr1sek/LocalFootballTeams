using LocalFootballTeam.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalFootballTeam.Migrations
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbContext(DbContextOptions<DbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(u => u.Name)
                .IsRequired();

            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id=1,
                    Name = "User"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Editor"
                },
                new Role()
                {
                    Id=3,
                    Name = "Admin"
                });
                
        }

        #region OnConfiguring
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=LocalFootballTeamDB;Trusted_Connection=True;TrustServerCertificate=true;");
        }
        #endregion

        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
