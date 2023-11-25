using Manazor.Application.Features.Employees.Queries.GetAllEmployees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Warehouses.Command.Create
{
    public class CreateWarehouseCommand : IRequest
    {
        public string Name { get; set; } = null!;

        public GetAllWorkCentersDto WorkCenterDto { get; set; } = null!;
    }
}
