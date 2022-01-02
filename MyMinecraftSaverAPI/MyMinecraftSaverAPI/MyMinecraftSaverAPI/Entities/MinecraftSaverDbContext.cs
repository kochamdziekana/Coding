using Microsoft.EntityFrameworkCore;

namespace MyMinecraftSaverAPI.Entities
{
    public class MinecraftSaverDbContext : DbContext
    {
        private string _connectionString =
            "(Server)=(localdb)\\mssqllocaldb;Database=MinecraftSaverDb;Trusted_Connection=True;";

        public MinecraftSaverDbContext(DbContextOptions<MinecraftSaverDbContext> options) : base(options)
        {

        }

        public DbSet<World> Worlds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)  // overrides constructor that is above
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Login)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(r => r.Name)
                .IsRequired();

            modelBuilder.Entity<World>()
                .Property(w => w.Name)
                .IsRequired();
        }
    }
}
