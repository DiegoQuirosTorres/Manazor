using Manazor.Application.Common.Mappings;
using Manazor.Domain.Entities.WarehouseModule;
using Manazor.Domain.Entities.WorkCenterModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Warehouses.Queries
{
    public class GetAllWarehousesDto : IMapFrom<Warehouse>
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
