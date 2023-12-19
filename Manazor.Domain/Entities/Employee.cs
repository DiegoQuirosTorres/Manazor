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

		public byte[]? Photo { get; set; }

        public string Email { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;

		public string? Address { get; set;} = string.Empty;

		public string? City { get; set; } = string.Empty;

		public string? Province { get; set; } = string.Empty;

		public int? WorkCenterId { get; set; }

		public DateTime? BirthDate { get; set; }

    }
}
