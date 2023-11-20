using Manazor.Application.Features.WorkCenters.Commands.Create;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities.WorkCenterModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.WorkCenters.Commands.Update
{
    public class UpdateWorkCenterHandler : IRequestHandler<UpdateWorkCenterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateWorkCenterHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateWorkCenterCommand request, CancellationToken cancellationToken)
        {
            WorkCenter workCenter = await _unitOfWork.Repository<WorkCenter>().GetByIdAsync(request.Id);

            workCenter.Province = request.Province;
            workCenter.City = request.City;
            workCenter.Address = request.Address;
            workCenter.Denomination = request.Denomination;

            await _unitOfWork.Repository<WorkCenter>().UpdateAsync(workCenter);

            await _unitOfWork.Save(cancellationToken);
        }
    }
}
