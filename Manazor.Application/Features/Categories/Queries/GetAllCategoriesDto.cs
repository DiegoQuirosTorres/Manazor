using Manazor.Application.Common.Mappings;
using Manazor.Domain.Entities.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Categories.Queries
{
    public class GetAllCategoriesDto : IMapFrom<Category>
    {
        public int Id { get; set; }
        public int LogoId { get; set; }

        public string Color { get; set; } = null!;

        public string Name { get; set; } = null!;
    }
}
