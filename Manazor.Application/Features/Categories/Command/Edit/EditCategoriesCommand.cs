using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Categories.Command.Edit
{
    public class EditCategoriesCommand : IRequest
    {
        public int Id { get; set; }
        public int LogoId { get; set; }

        public string Color { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
