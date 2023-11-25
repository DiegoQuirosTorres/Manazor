using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Domain.Entities.ProductModule
{
    public class Category : BaseAuditableEntity
    {
        public int LogoId { get; set; }

        public string Color { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
