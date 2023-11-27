using Manazor.Application.Common.Mappings;
using Manazor.Domain.Entities.ProductModule;
using Manazor.Domain.Entities.WarehouseModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Products.Queries
{
    public class GetAllProductsDto : IMapFrom<Product>
    { 
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[]? Photo { get; set; }

        public int LowQuantity { get; set; }

        public int Category { get; set; } = 1;

        public decimal Price { get; set; }
    }
}
