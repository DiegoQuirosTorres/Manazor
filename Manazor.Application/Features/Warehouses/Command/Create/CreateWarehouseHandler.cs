using Manazor.Application.Features.WorkCenters.Commands.Create;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities.WarehouseModule;
using Manazor.Domain.Entities.WorkCenterModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Warehouses.Command.Create
{
    internal class CreateWarehouseHandler : IRequestHandler<CreateWarehouseCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateWarehouseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
        {
            Warehouse warehouse = new Warehouse
            {
                Name = request.Name,
                workCenterId = request.WorkCenterDto.Id,
            };

            await _unitOfWork.Repository<Warehouse>().AddAsync(warehouse);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
