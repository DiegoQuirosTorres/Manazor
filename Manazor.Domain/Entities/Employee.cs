using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Domain.Entities
{
	public class Employee : BaseAuditableEntity
	{
		public string Name { get; set; } = null!;

		public string Surname { get; set; } = null!;
	}
}
