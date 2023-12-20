using Manazor.Application.Features.Employees.Command.RegisterEmployee;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities;
using Manazor.Domain.Entities.WarehouseModule;
using MediatR;

namespace Manazor.Application.Features.Employees.Command.EditEmployee
{
    public class EditEmployeeHandler : IRequestHandler<EditEmployeeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditEmployeeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
        {
            Employee employee = await _unitOfWork.Repository<Employee>().GetByIdAsync(request.Id);

            employee.Province = request.Province;

            employee.Address = request.Address;

            employee.City = request.City;

            employee.Password = request.Password;

            employee.RoleId = request.RoleId;

            employee.WorkCenterId = request.WorkCenterId;

            await _unitOfWork.Repository<Employee>().UpdateAsync(employee);

            await _unitOfWork.Save(cancellationToken);
        }
    }
}
