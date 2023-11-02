using Manazor.Domain.Common.Interfaces;

namespace Manazor.Domain.Entities
{
	public class BaseAuditableEntity : BaseEntity, IAuditableEntity
	{
		public int? CreatedBy { get; set; }
		public DateTime? CreatedDate { get; set; }
		public int? UpdateBy { get; set; }
		public DateTime? UpdateDate { get; set; }
	}
}
