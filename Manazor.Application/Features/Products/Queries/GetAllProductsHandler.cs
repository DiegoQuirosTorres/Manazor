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

namespace Manazor.Application.Features.Products.Queries
{
    public record GetAllProducts : IRequest<List<GetAllProductsDto>>;

    internal class GetAllProductsHandler : IRequestHandler<GetAllProducts, List<GetAllProductsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductsDto>> Handle(GetAllProducts request, CancellationToken cancellationToken)
        {
            var dtos = await _unitOfWork.Repository<Product>().Entities
                             .Join(_unitOfWork.Repository<Category>().Entities,
                                      product => product.Category,
                                      category => category.Id,
                               (product, category) => new GetAllProductsDto
                               {
                                   Id = product.Id,
                                   Name = product.Name,
                                   Category = product.Category,
                                   CategoryName = category.Name,
                                   Color = category.Color,
                                   Description = product.Description,
                                   IconId = category.LogoId,
                                   LowQuantity = product.LowQuantity,
                                   Photo = product.Photo,
                                   Price = product.Price,
                               })
                              .ToListAsync(cancellationToken);

            return dtos;
        }
    }
}
