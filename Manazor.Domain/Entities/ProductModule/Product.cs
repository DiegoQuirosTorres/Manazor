using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Domain.Entities.ProductModule
{
    public class Product : BaseAuditableEntity
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[]? Photo { get; set; }

        public int LowQuantity { get; set; }

        public int Category { get; set; }

        public decimal Price { get; set; }
    }
}
