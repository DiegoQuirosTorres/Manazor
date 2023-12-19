using Manazor.Application.Features.Categories.Command.Create;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities;
using Manazor.Domain.Entities.ProductModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Warehouses.Command.AddProductsInWarehouses
{
    internal class AddProductsInWarehousesHandler : IRequestHandler<AddProductsInWarehousesCommand>
    {
        private readonly IProductWarehouseRepository _productWarehouseRepository;

        public AddProductsInWarehousesHandler(IProductWarehouseRepository productWarehouseRepository)
        {
            _productWarehouseRepository = productWarehouseRepository;
        }

        public async Task Handle(AddProductsInWarehousesCommand request, CancellationToken cancellationToken)
        {
            var entry = await _productWarehouseRepository.GetByIdAsync(request.ProductId, request.WarehouseId);

            if(entry == null)
            {
                await _productWarehouseRepository.AddAsync(new ProductWarehouse
                {
                    ProductId = request.ProductId,
                    WarehouseId = request.WarehouseId,
                    Quantity = request.Quantity
                });
            }
            else
            {
                entry.Quantity += request.Quantity;

                await _productWarehouseRepository.UpdateAsync(entry);
            }
        }
    }
}
