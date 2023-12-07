using Manazor.Application.Common.Mappings;
using Manazor.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Auth.Login
{
    public class EmployeeInfoDto : IMapFrom<Employee>
    {
        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public byte[]? Photo { get; set; }

        //public List<int> RolesIds { get; set; }
    }
}
