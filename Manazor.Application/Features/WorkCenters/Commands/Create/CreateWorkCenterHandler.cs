using AutoMapper;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities.WorkCenterModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.WorkCenters.Commands.Create
{
    internal class CreateWorkCenterHandler : IRequestHandler<CreateWorkCenterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateWorkCenterHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateWorkCenterCommand request, CancellationToken cancellationToken)
        {
            WorkCenter workCenter = new WorkCenter
            {
                Denomination = request.Denomination,
                City = request.City,
                Province = request.Province,
                Address = request.Address,
            };

            await _unitOfWork.Repository<WorkCenter>().AddAsync(workCenter);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
