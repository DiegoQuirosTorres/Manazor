using Manazor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Interfaces.Repositories
{
    public interface IProductWarehouseRepository
    {
        IQueryable<ProductWarehouse> Entities { get; }

        Task<ProductWarehouse> GetByIdAsync(int productId, int warehouseId);
        Task<List<ProductWarehouse>> GetAllAsync(int warehouseId);
        Task<ProductWarehouse> AddAsync(ProductWarehouse entity);
        Task UpdateAsync(ProductWarehouse entity);
        Task DeleteAsync(ProductWarehouse entity);
    }
}
