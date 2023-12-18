using Manazor.Domain.Entities.ProductModule;
using Manazor.Domain.Entities.WarehouseModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Warehouses.Queries.GetProductsInWarehouse
{
    public class GetProductsInWarehouseDto
    {
        public int WarehouseId { get; set; }

        public byte[]? ProductPhoto { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public int LogoId { get; set; }

        public string CategoryColor { get; set; }

        public string CategoryName { get; set; }
    }
}
