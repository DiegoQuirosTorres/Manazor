using Manazor.Application.Features.Categories.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Products.Commands.Create
{
    public class CreateProductsCommand : IRequest
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[]? Photo { get; set; }

        public int LowQuantity { get; set; }

        public int Category { get; set; } = 1;

        public decimal Price { get; set; }
    }
}
