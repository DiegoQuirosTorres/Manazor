using Manazor.Application.Features.Categories.Command.Create;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities;
using Manazor.Domain.Entities.ProductModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Employees.Command.RegisterEmployee
{
    internal class RegisterEmployeeHandler : IRequestHandler<RegisterEmployeeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterEmployeeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(RegisterEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = new Employee
            {
                Name = request.Name,
                Email = request.Email.ToLower(),
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Photo = request.Photo,
                Surname = request.Surname,
                Address = request.Address,
                City = request.City,
                Province = request.Province,
                BirthDate = request.BirthDate,
                WorkCenterId = request.WorkCenterId,
        };

            await _unitOfWork.Repository<Employee>().AddAsync(employee);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
