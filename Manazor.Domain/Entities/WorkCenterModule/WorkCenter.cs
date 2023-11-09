using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Domain.Entities.WorkCenterModule
{
    public class WorkCenter : BaseAuditableEntity
    {
        public string Province { get; set; } = null!;

        public string Denomination { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;
    }
}
