using AutoMapper;
using AutoMapper.QueryableExtensions;
using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities;
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

	internal class GetAllPlayersQueryHandler : IRequestHandler<GetAllEmployees, List<GetAllEmployeesDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public GetAllPlayersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<List<GetAllEmployeesDto>> Handle(GetAllEmployees query, CancellationToken cancellationToken)
		{
			return await _unitOfWork.Repository<Employee>().Entities
				   .ProjectTo<GetAllEmployeesDto>(_mapper.ConfigurationProvider)
				   .ToListAsync(cancellationToken);
		}
	}
}
