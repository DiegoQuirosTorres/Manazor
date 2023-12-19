using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Employees.Queries.GetEmployeePhoto
{
    public class GetEmployeePhotoRequest : IRequest<byte[]?>
    {
        public int EmployeeId { get; set; }
    }
}
