using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Warehouses.Queries.GetProductsInWarehouse
{
    public class GetProductsInWarehouses : IRequest<List<GetProductsInWarehouseDto>>
    {
        public int WarehouseId { get; set; }
    }
}
