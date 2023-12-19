using AutoMapper;
using AutoMapper.QueryableExtensions;
using Manazor.Application.Features.Employees.Queries.GetAllEmployees;
using Manazor.Application.Features.Warehouses.Queries;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities;
using Manazor.Domain.Entities.ProductModule;
using Manazor.Domain.Entities.WarehouseModule;
using Manazor.Domain.Entities.WorkCenterModule;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Roles.Queries
{
    public record GetAllRoles : IRequest<List<GetAllRolesDto>>;

    internal class GetAllRolesHandler : IRequestHandler<GetAllRoles, List<GetAllRolesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRolesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllRolesDto>> Handle(GetAllRoles request, CancellationToken cancellationToken)
        {

            return await _unitOfWork.Repository<Role>().Entities
               .ProjectTo<GetAllRolesDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
