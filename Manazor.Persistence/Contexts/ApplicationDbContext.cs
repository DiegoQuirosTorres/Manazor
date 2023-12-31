﻿using Manazor.Domain.Entities;
using Manazor.Domain.Entities.ProductModule;
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
        { ChangeTracker.LazyLoadingEnabled = true; }

		public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<WorkCenter> WorkCenters => Set<WorkCenter>();
		public DbSet<Warehouse> Warehouses => Set<Warehouse>();
		public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
		public DbSet<ProductWarehouse> ProductsWarehouses => Set<ProductWarehouse>();
        public DbSet<Role> Roles => Set<Role>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<ProductWarehouse>()
				.HasKey(pa => new { pa.WarehouseId, pa.ProductId });

            modelBuilder.Entity<Warehouse>()
                   .HasMany(e => e.Products)
                   .WithMany(e => e.Warehouses)
                   .UsingEntity<ProductWarehouse>(
                       l => l.HasOne<Product>(e => e.Product).WithMany(e => e.ProductWarehouses),
                       r => r.HasOne<Warehouse>(e => e.Warehouse).WithMany(e => e.ProductWarehouses));
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
