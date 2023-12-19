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
		public byte[]? Photo { get; set;}
		public string? Address { get; set; } = string.Empty;
		public string? City { get; set; } = string.Empty;
		public string? Province { get; set;} = string.Empty;
		public string? WorkCenterName { get; set; } = string.Empty;
		public int? WorkCenterId { get; set; }
		public string Email { get; set; } = string.Empty;
		public DateTime? BirthDate { get; set; }
		public int RoleId { get; set; }
		public string RoleName { get; set; }
	}
}
