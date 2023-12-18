using Manazor.Domain.Entities.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Domain.Entities.WarehouseModule
{
    public class Warehouse : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;

        public int WorkCenterId { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

        public ICollection<ProductWarehouse> ProductWarehouses { get; set; }
    }
}
