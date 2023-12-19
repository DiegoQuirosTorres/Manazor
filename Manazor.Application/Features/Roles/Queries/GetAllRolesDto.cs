using Manazor.Application.Common.Mappings;
using Manazor.Domain.Entities;
using Manazor.Domain.Entities.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Roles.Queries
{
    public class GetAllRolesDto : IMapFrom<Role>
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
    }
}
