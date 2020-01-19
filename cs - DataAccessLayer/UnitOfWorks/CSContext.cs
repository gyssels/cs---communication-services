using csDataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace csDataAccessLayer.UnitOfWorks
{
	public class CSContext : DbContext
	{
		public CSContext()
		{ 
		}

		public CSContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=InitialMigration;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
		
		public DbSet<MessageEF> Messages { get; set; }
	}
}
