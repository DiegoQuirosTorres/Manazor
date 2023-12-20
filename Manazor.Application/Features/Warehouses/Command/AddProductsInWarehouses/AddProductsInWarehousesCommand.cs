using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Warehouses.Command.AddProductsInWarehouses
{
    public class AddProductsInWarehousesCommand : IRequest
    {
        public int WarehouseId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
