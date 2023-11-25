using Manazor.Application.Features.Categories.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Products
{
    public class CreateProductsCommand : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public int LowQuantity { get; set; }

        public int Category { get; set; }

        public decimal Price { get; set; }
    }
}
