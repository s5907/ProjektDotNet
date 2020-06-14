using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProjektDotNet.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    
        public DbSet<Player> Players { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<SportType> SportTypes { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Competition> Competitions { get; set; }
      

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}