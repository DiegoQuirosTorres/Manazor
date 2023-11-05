using Manazor.Application.Common.Mappings;
using Manazor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Employees.Queries.GetAllEmployees
{
	public class GetAllEmployeesDto : IMapFrom<Employee>
	{
		public string Name { get; set; } = null!;
		public string Surname { get; set; } = null!;
	}
}
