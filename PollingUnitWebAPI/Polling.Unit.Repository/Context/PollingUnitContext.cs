using Microsoft.EntityFrameworkCore;
using Polling.Unit.Repository.DBTableObjects;

namespace Polling.Unit.Repository.Context
{
    public class PollingUnitContext : DbContext
    {
        public virtual DbSet<UserInfo> USER_INFO { get; set; }

        public PollingUnitContext(DbContextOptions<PollingUnitContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.Property(e => e.USER_NAME).IsRequired();
                entity.Property(e => e.PASSWORD).IsRequired();
            });
        }
    }
}
    