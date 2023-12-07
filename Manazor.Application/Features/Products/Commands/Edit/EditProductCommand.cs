using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Products.Commands.Edit
{
    public class EditProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[]? Photo { get; set; }

        public int LowQuantity { get; set; }

        public int Category { get; set; } = 1;

        public double Price { get; set; }
    }
}
