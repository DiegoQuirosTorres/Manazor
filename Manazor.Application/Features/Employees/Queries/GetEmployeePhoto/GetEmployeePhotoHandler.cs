using AutoMapper;
using Manazor.Application.Features.Employees.Queries.GetAllEmployees;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities.WorkCenterModule;
using Manazor.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Employees.Queries.GetEmployeePhoto
{
    internal class GetEmployeePhotoHandler : IRequestHandler<GetEmployeePhotoRequest, byte[]?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEmployeePhotoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<byte[]?> Handle(GetEmployeePhotoRequest query, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<Employee>().GetByIdAsync(query.EmployeeId);

            return result.Photo;
        }
    }
}
