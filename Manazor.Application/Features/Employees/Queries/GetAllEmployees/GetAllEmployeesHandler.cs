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
	public record GetAllEmployees : IRequest<List<GetAllEmployeesDto>>;

	internal class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployees, List<GetAllEmployeesDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllEmployeesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<List<GetAllEmployeesDto>> Handle(GetAllEmployees query, CancellationToken cancellationToken)
		{
			var result = await _unitOfWork.Repository<Employee>().Entities
				   .ProjectTo<GetAllEmployeesDto>(_mapper.ConfigurationProvider)
				   .ToListAsync(cancellationToken);

			foreach(var e in result)
			{
				if(e.WorkCenterId != null)
				{
					var workCenter = await _unitOfWork.Repository<WorkCenter>().GetByIdAsync(e.WorkCenterId.Value);

					e.WorkCenterName = workCenter.Denomination;
                }
            }

			return result;
		}
	}
}
