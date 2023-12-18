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
        private readonly IProductWarehouseRepository _productWarehouseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductsInWarehouseHandler(IProductWarehouseRepository productWarehouseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productWarehouseRepository = productWarehouseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetProductsInWarehouseDto>> Handle(GetProductsInWarehouses request, CancellationToken cancellationToken)
        {
            var dtos = await _productWarehouseRepository.GetAllAsync(request.WarehouseId);

            List<GetProductsInWarehouseDto> result = new List<GetProductsInWarehouseDto>();

            dtos.ForEach(async p => {
                //for some reason Include with EF dont give me the entities of Product and Warehouse joined on ProductWarehouse, so i have to request them manually
                var product = await _unitOfWork.Repository<Product>().GetByIdAsync(p.ProductId);

                var category = await _unitOfWork.Repository<Category>().GetByIdAsync(product.Category);

                result.Add(new GetProductsInWarehouseDto
                {
                    ProductId = p.ProductId,
                    ProductName = product.Name,
                    ProductPhoto = product.Photo,
                    Quantity = p.Quantity,
                    WarehouseId = p.WarehouseId,
                    CategoryColor = category.Color,
                    CategoryName = category.Name,
                    LogoId = category.LogoId,
                });
            });

            return result;
        }
    }
}
