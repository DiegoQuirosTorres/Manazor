using Manazor.Application.Features.Warehouses.Command.AddProductsInWarehouses;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities;
using Manazor.Domain.Entities.WarehouseModule;
using Manazor.Domain.Entities.WorkCenterModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Warehouses.Command.Edit
{
    internal class EditWarehouseHandler : IRequestHandler<EditWarehouseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditWarehouseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EditWarehouseCommand request, CancellationToken cancellationToken)
        {
            Warehouse warehouse = await _unitOfWork.Repository<Warehouse>().GetByIdAsync(request.Id);

            warehouse.Name = request.Name;

            await _unitOfWork.Repository<Warehouse>().UpdateAsync(warehouse);

            await _unitOfWork.Save(cancellationToken);
        }
    }
}
