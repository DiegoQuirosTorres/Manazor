using Manazor.Application.Features.Employees.Queries.GetAllEmployees;
using Manazor.Application.Features.Warehouses.Command.Create;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities;
using Manazor.Domain.Entities.WarehouseModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Auth.Login
{
    internal class LoginHandler : IRequestHandler<LoginCommand, EmployeeInfoDto?>
    {
        private readonly IAuthService _authService;

        public LoginHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<EmployeeInfoDto?> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            Employee? loginData = await _authService.Login(request.Email, request.Password);

            if (loginData != null)
            {
                return new EmployeeInfoDto
                {
                    Email = loginData.Email,
                    Name = loginData.Name,
                    Photo = loginData.Photo
                };
            }
            else
            {
                return null;
            }
        }
    }
}
