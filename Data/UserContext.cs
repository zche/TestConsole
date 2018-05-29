using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace testConsole
{
    public class UserContext : DbContext
    {
        //public UserContext(DbContextOptions<UserContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;port=3306;database=beta_user;userid=root;password=Zrf123456!;SslMode=none;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .ToTable("Users")
                .HasKey(u => u.Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}
