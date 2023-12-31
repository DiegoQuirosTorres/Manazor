﻿using Manazor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Application.Interfaces.Repositories
{
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity;
        IProductWarehouseRepository ProductWarehouseRepository();
        Task<int> Save(CancellationToken cancellationToken);
		Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
		Task Rollback();
	}
}
