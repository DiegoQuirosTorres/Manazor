using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Domain.Common.Interfaces
{
	public interface IAuditableEntity : IEntity
	{
		int? CreatedBy { get; set; }
		DateTime? CreatedDate { get; set; }
		int? UpdateBy { get; set; }
		DateTime? UpdateDate { get; set; }
	}
}
