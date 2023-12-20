using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Employees.Command.EditEmployee
{
    public class EditEmployeeCommand : IRequest
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public byte[] Photo { get; set; }

        public int RoleId { get; set; }

        public int WorkCenterId { get; set; }
    }
}
