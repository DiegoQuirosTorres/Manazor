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
            return await _unitOfWork.Repository<Warehouse>().Entities
               .ProjectTo<GetAllWarehousesDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
