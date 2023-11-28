using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities.ProductModule;
using MediatR;

namespace Manazor.Application.Features.Products.Commands.Create
{
    internal class CreateProducsHandler : IRequestHandler<CreateProductsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProducsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateProductsCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                LowQuantity = request.LowQuantity,
                Photo = request.Photo,
                Price = request.Price,
                CreatedDate = DateTime.Now
            };

            await _unitOfWork.Repository<Product>().AddAsync(product);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
