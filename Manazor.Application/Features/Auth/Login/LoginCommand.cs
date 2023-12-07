using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Auth.Login
{
    public class LoginCommand : IRequest<EmployeeInfoDto?>
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
