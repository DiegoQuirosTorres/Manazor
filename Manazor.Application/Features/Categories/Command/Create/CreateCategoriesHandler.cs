using Manazor.Application.Features.Warehouses.Command.Create;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities.ProductModule;
using Manazor.Domain.Entities.WarehouseModule;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Categories.Command.Create
{
    internal class CreateCategoriesHandler : IRequestHandler<CreateCategoriesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoriesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCategoriesCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category
            {
                Color = request.Color,
                LogoId = request.LogoId,
                Name = request.Name,
            };

            await _unitOfWork.Repository<Category>().AddAsync(category);
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
