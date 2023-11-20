using Manazor.Domain.Entities;
using Manazor.Domain.Entities.WarehouseModule;
using Manazor.Domain.Entities.WorkCenterModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Persistence.Contexts
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{ }

		public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<WorkCenter> WorkCenters => Set<WorkCenter>();
		public DbSet<Warehouse> Warehouses => Set<Warehouse>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
		{
			return await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
		}

		public override int SaveChanges()
		{
			return SaveChangesAsync().GetAwaiter().GetResult();
		}
	}
}
