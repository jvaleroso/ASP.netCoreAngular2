using Microsoft.EntityFrameworkCore;
using BoomFinance.Core;

namespace BoomFinance.Data
{
	public class FinanceContext : DbContext
	{
		public FinanceContext(DbContextOptions<FinanceContext> options) : base(options)
		{
		}

		public DbSet<Bank> Banks { get; set; }
	}
}
