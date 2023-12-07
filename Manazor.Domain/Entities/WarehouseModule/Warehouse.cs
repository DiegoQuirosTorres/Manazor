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

        public int workCenterId { get; set; }

        public ICollection<ProductWarehouse> ProductWarehouses { get; set; }
    }
}
