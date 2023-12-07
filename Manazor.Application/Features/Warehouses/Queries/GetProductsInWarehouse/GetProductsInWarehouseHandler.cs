using AutoMapper;
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

namespace Manazor.Application.Features.Warehouses.Queries.GetProductsInWarehouse
{
    internal class GetProductsInWarehouseHandler : IRequestHandler<GetProductsInWarehouses, List<GetProductsInWarehouseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductsInWarehouseHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetProductsInWarehouseDto>> Handle(GetProductsInWarehouses request, CancellationToken cancellationToken)
        {
            var dtos = await _unitOfWork.ProductWarehouseRepository().Entities
                   .Join(_unitOfWork.Repository<Product>().Entities,
                            warehouseProduct => warehouseProduct.ProductId,
                            product => product.Id,
                     (warehouseProduct, product) => new GetProductsInWarehouseDto
                     {
                         ProductId = warehouseProduct.ProductId,
                         WarehouseId = warehouseProduct.WarehouseId,
                         ProductName = product.Name,
                         ProductPhoto = product.Photo,
                         Quantity = warehouseProduct.Quantity,
                     })
                    .ToListAsync(cancellationToken);

            return dtos;
        }
    }
}
