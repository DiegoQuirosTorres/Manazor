using AutoMapper;
using AutoMapper.QueryableExtensions;
using Manazor.Application.Features.Employees.Queries.GetAllEmployees;
using Manazor.Application.Features.Warehouses.Queries;
using Manazor.Application.Interfaces.Repositories;
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

namespace Manazor.Application.Features.Categories.Queries
{
    public record GetAllCategories : IRequest<List<GetAllCategoriesDto>>;

    internal class GetAllCategoriesHandler : IRequestHandler<GetAllCategories, List<GetAllCategoriesDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllCategoriesDto>> Handle(GetAllCategories request, CancellationToken cancellationToken)
        {

            return await _unitOfWork.Repository<Category>().Entities
               .ProjectTo<GetAllCategoriesDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);
        }
    }
}
