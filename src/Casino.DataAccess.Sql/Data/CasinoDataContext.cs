using Casino.DataAccess.Sql.Entities;
using Microsoft.EntityFrameworkCore;

namespace Casino.DataAccess.Sql.Data
{
    public class CasinoDataContext : DbContext
    {
        public CasinoDataContext(DbContextOptions<CasinoDataContext> options) : base(options)
        {
        }
        public DbSet<UserAccountEntity> UserAccount { get; set; } = null!;
        public DbSet<GameRecordEntity> GameRecord { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameRecordEntity>()
                .HasOne(g => g.UserAccount)
                .WithMany(u => u.GameRecords)
                .HasForeignKey(g => g.UserId);
            modelBuilder.Entity<UserAccountEntity>();
        }
    }
}
