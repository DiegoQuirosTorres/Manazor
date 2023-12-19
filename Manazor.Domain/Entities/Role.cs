using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Domain.Entities
{
    public class Role : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
