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

namespace Manazor.Application.Features.Categories.Command.Edit
{
    internal class EditCategoryHandler : IRequestHandler<EditCategoriesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(EditCategoriesCommand request, CancellationToken cancellationToken)
        {
            Category category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.Id);

            category.Name = request.Name;
            category.LogoId = request.LogoId;
            category.Color = request.Color;

            await _unitOfWork.Repository<Category>().UpdateAsync(category);

            await _unitOfWork.Save(cancellationToken);
        }
    }
}
