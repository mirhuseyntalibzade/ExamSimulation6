using CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contexts
{
    public class AppDBContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> opt) : base(opt) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "4428cfb1-09e1-4e8c-a72e-822eb3d48570", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "73566fe1-b077-4829-b445-af4461267d97", Name = "User", NormalizedName = "USER" }
                );

            IdentityUser admin = new IdentityUser
            {
                Id = "26294cb6-1fca-4cf5-93e4-f742cae69c68",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM"
            };

            PasswordHasher<IdentityUser> hasher = new();
            admin.PasswordHash = hasher.HashPassword(admin,"Admin123!");

            builder.Entity<IdentityUser>().HasData( admin );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = "4428cfb1-09e1-4e8c-a72e-822eb3d48570", UserId = "26294cb6-1fca-4cf5-93e4-f742cae69c68" }
            );

            base.OnModelCreating(builder);
        }
    }
}
