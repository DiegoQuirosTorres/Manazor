using Manazor.Application.Common.Mappings;
using Manazor.Domain.Entities;
using Manazor.Domain.Entities.WorkCenterModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Employees.Queries.GetAllEmployees
{
	public class GetAllWorkCentersDto : IMapFrom<WorkCenter>
	{
		public int Id { get; set; }
		public string Denomination { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
