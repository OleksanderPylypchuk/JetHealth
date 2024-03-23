using JetHealth.Models;
using JetHealth.Models.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JetHealth.Data.DBContext
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<TImage> Images { get; set; }
        public DbSet<TDescription> TDescriptions { get; set; }
        public DbSet<TProcedure> Procedures { get; set; }
        public DbSet<ApplicationUser> Users {  get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Review> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
