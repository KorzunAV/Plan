using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Entities.Entity;

namespace Data.EntityFramework
{
	public class PlanContext : DbContext
    {
        public DbSet<CashAccount> CashAccount { get; set; }
        public DbSet<TransferSubType> TransferSubType { get; set; }
        public DbSet<CurrencyType> CurrencyType { get; set; }
        public DbSet<ExchangeArchive> ExchangeArchive { get; set; }
        public DbSet<SystemUser> SystemUser { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TransferType> TransferType { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<СashTransfer> СashTransfer { get; set; }

		/// <summary>
		/// Препятствует тому, чтобы названия таблицы были переведены во множественное число
		/// </summary>
		/// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
