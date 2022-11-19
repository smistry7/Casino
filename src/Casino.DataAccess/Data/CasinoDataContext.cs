using Casino.DataAccess.Sql.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.Sql.Data
{
    public class CasinoDataContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<GameRecordEntity> Games { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost,8123;Initial Catalog=CasinoDatabase;User ID=sa;Password=YourS3cureP@ass");
        }
    }
}
