using AutoMapper;
using AutoMapper.QueryableExtensions;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities;
using Manazor.Domain.Entities.WorkCenterModule;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Features.Employees.Queries.GetAllEmployees
{
	public record GetAllWorkCenters : IRequest<List<GetAllWorkCentersDto>>;

	internal class GetAllWorkCentersHandler : IRequestHandler<GetAllWorkCenters, List<GetAllWorkCentersDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllWorkCentersHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

        public async Task<List<GetAllWorkCentersDto>> Handle(GetAllWorkCenters request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<WorkCenter>().Entities
			   .ProjectTo<GetAllWorkCentersDto>(_mapper.ConfigurationProvider)
			   .ToListAsync(cancellationToken);
        }
    }
}
