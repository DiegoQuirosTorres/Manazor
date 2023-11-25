using AutoMapper;
using AutoMapper.QueryableExtensions;
using Manazor.Application.Features.Employees.Queries.GetAllEmployees;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities.WarehouseModule;
using Manazor.Domain.Entities.WorkCenterModule;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Warehouses.Queries
{
    public record GetAllWarehouses : IRequest<List<GetAllWarehousesDto>>;

    internal class GetAllWorkCentersHandler : IRequestHandler<GetAllWarehouses, List<GetAllWarehousesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWorkCentersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllWarehousesDto>> Handle(GetAllWarehouses request, CancellationToken cancellationToken)
        {
            var dtos = await _unitOfWork.Repository<Warehouse>().Entities
                   .Join(_unitOfWork.Repository<WorkCenter>().Entities,
                            warehouse => warehouse.Id,
                            workCenter => workCenter.Id,
                     (warehouse, workCenter) => new GetAllWarehousesDto
                     {
                         Id = warehouse.Id,
                         Name = warehouse.Name,
                         WorkCenterId = workCenter.Id,
                         WorkCenterName = workCenter.Denomination,
                         WorkCenterAddress = workCenter.Address,
                     })
                    .ToListAsync(cancellationToken);     

            /*foreach(GetAllWarehousesDto d in dtos)
            {
                var workCenter = await _unitOfWork.Repository<WorkCenter>()
                    .GetByIdAsync(d.Id);
                d.WorkCenterName = workCenter.Denomination;
                d.WorkCenterAddress = workCenter.Address;
            }*/

            return dtos;
        }
    }
}
