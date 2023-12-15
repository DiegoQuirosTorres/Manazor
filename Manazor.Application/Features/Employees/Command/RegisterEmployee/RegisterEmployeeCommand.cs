using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Employees.Command.RegisterEmployee
{
    public class RegisterEmployeeCommand : IRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime? BirthDate { get; set; }

        public byte[] Photo { get; set; }

        public string Province { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;

        public int WorkCenterId { get; set; }
    }
}
