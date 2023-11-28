using Manazor.Application.Features.WorkCenters.Commands.Update;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities.ProductModule;
using Manazor.Domain.Entities.WorkCenterModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Products.Commands.Edit
{
    internal class EditProductHandler : IRequestHandler<EditProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditProductHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id);

            product.Name = request.Name;
            product.Description = request.Description;
            product.Category = request.Category;
            product.Photo = request.Photo;
            product.Price = request.Price;
            product.LowQuantity = request.LowQuantity;

            await _unitOfWork.Repository<Product>().UpdateAsync(product);

            await _unitOfWork.Save(cancellationToken);
        }
    }
}
