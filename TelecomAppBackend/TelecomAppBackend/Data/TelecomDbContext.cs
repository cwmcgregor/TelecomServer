using Microsoft.EntityFrameworkCore;
using TelecomAppBackend.Models;

namespace TelecomAppBackend.Data
{
    public class TelecomDbContext:DbContext
    {
        public TelecomDbContext(DbContextOptions<TelecomDbContext>options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Plan>Plans { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plan>()
                .HasOne<User>(p => p.User)
                .WithMany(d => d.Plans)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Device>()
                .HasOne<Plan>(p => p.Plan)
                .WithMany(d => d.Devices)
                .HasForeignKey(f => f.PlanId);

            modelBuilder.Entity<Device>()
                .HasIndex(p => p.PhoneNumber)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();
        }
        

     

    }
}
