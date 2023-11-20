using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.WorkCenters.Commands.Update
{
    public class UpdateWorkCenterCommand : IRequest
    {
        public int Id { get; set; }
        public string Denomination { get; set; } = null!;
        public string Province { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
