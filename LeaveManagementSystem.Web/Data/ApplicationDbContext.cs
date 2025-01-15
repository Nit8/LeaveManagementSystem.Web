using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "AB3BE125-8C2F-4CC3-8FA7-AD89444881F1",
                Name = " Employee",
                NormalizedName = "EMPLOYEE"
            },
                new IdentityRole
                {
                    Id= "94F84E62-BAF7-4104-9E9F-72BC5C2FEC74",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                },
                new IdentityRole
                {
                    Id = "0BE0F80A-1740-4581-BAF0-AE46552A4356",
                    Name = "Administrator",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "E3B865DF-FA5C-4FE7-92AA-F6E6BB54C79C",
                    Name = "Guest",
                    NormalizedName = "GUEST"
                });

            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "0BF2F227-25EC-4F6F-A333-04DC64E2BCF3",
                    Email = "nitesh.singh1423.nl@gmail.com",
                    NormalizedEmail = "NITESH.SINGH1423.NL@GMAIL.COM",
                    NormalizedUserName = "NITESH.SINGH1423.NL@GMAIL.COM",
                    UserName = "nitesh.singh1423.nl@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Leavemanagement@1"),
                    EmailConfirmed = true,
                    DateOfBirth = new DateOnly(1998, 05, 04),
                    FirstName = "Nitesh",
                    LastName = "Singh"
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "0BE0F80A-1740-4581-BAF0-AE46552A4356",
                    UserId = "0BF2F227-25EC-4F6F-A333-04DC64E2BCF3"
                }
                );
        }
        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
