using MertCord_Client.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace MertCord_Client.Context
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql($"Host={Environment.GetEnvironmentVariable("POSTGRE_URL")!};Port={Environment.GetEnvironmentVariable("POSTGRE_PORT")!};Database={Environment.GetEnvironmentVariable("POSTGRE_DB_NAME")!};Username={Environment.GetEnvironmentVariable("POSTGRE_DB_USER")!};Password={Environment.GetEnvironmentVariable("POSTGRE_DB_PASS")!};");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log_TBL>()
            .Property(e => e.CreateDate)
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
            .HasColumnType("timestamp with time zone");

            modelBuilder.Entity<Chat_TBL>()
            .Property(e => e.CreateDate)
            .HasConversion(
                v => v.ToUniversalTime(),
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
            .HasColumnType("timestamp with time zone");
        }
        public DbSet<Log_TBL> Log_TBLs { get; set; }
        public DbSet<Chat_TBL> Chat_TBLs { get; set; }

    }
}