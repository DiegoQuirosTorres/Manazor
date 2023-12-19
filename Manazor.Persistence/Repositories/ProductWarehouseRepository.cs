using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Common.Interfaces;
using Manazor.Domain.Entities;
using Manazor.Domain.Entities.ProductModule;
using Manazor.Domain.Entities.WarehouseModule;
using Manazor.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Manazor.Persistence.Repositories
{
    internal class ProductWarehouseRepository : IProductWarehouseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductWarehouseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<ProductWarehouse> Entities =>  _dbContext.Set<ProductWarehouse>();

        public async Task<ProductWarehouse> AddAsync(ProductWarehouse entity)
        {
            await _dbContext.Set<ProductWarehouse>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public Task DeleteAsync(ProductWarehouse entity)
        {
            _dbContext.Set<ProductWarehouse>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<ProductWarehouse>> GetAllAsync(int warehouseId)
        {
            return await _dbContext
                .Set<ProductWarehouse>()
                .Where(p => p.WarehouseId == warehouseId)
                .ToListAsync();
        }

        public async Task<ProductWarehouse?> GetByIdAsync(int productId, int warehouseId)
        {
            ProductWarehouse? entity = await _dbContext.Set<ProductWarehouse>().Where(p => p.ProductId == productId && p.WarehouseId == warehouseId).FirstAsync();

            return entity;
        }
        public async Task UpdateAsync(ProductWarehouse entity)
        {
            ProductWarehouse? exist = await _dbContext.Set<ProductWarehouse>().Where(p => p.ProductId == entity.ProductId && p.WarehouseId == entity.WarehouseId).FirstAsync();

            if (exist == null)
                throw new ArgumentNullException(nameof(exist));

            _dbContext.Entry(exist).CurrentValues.SetValues(entity);

            await _dbContext.SaveChangesAsync();
        }
    }
}
