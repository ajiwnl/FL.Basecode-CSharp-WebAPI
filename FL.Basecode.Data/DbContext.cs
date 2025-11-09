using FL.Basecode.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace FL.Basecode.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor to pass options (like connection string)
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets for your tables
        public DbSet<mUsers> Users { get; set; }
        public DbSet<mIcons> Icons { get; set; }
        public DbSet<mAccounts> Accounts { get; set; }

        // Optional: configure relationships using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Account -> User relationship
            modelBuilder.Entity<mAccounts>()
                .HasOne(a => a.Users)
                .WithMany(u => u.Accounts)
                .HasForeignKey(a => a.userId)
                .OnDelete(DeleteBehavior.Cascade);

            // Account -> Icon relationship
            modelBuilder.Entity<mAccounts>()
                .HasOne(a => a.Icons)
                .WithMany(i => i.Accounts)
                .HasForeignKey(a => a.iconId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
