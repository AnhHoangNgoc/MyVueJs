using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyVueJs.Data.Entities;

namespace MyVueJs.Data
{
    public class ECommerceContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Products> Products { get; set; }
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Products>()
            .HasIndex(b => b.Slug)
            .IsUnique();
        }
    }
}