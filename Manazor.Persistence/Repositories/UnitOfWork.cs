﻿using Manazor.Application.Interfaces.Repositories;
using Manazor.Domain.Entities;
using Manazor.Persistence.Contexts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manazor.Persistence.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _dbContext;
		private Hashtable _repositories;
		private Hashtable _produtWarehouseRepository;
		private bool disposed;

		public UnitOfWork(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
		}

		public IGenericRepository<T> Repository<T>() where T : BaseAuditableEntity
		{
			if (_repositories == null)
				_repositories = new Hashtable();

			var type = typeof(T).Name;

			if (!_repositories.ContainsKey(type))
			{
				var repositoryType = typeof(GenericRepository<>);

				var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), _dbContext);

				_repositories.Add(type, repositoryInstance);
			}

			return (IGenericRepository<T>)_repositories[type];
		}

        public IProductWarehouseRepository ProductWarehouseRepository()
        {
            if (_produtWarehouseRepository == null)
                _produtWarehouseRepository = new Hashtable();

            var type = typeof(ProductWarehouse).Name;

            if (!_produtWarehouseRepository.ContainsKey(type))
            {
                var repositoryType = typeof(ProductWarehouseRepository);

                var repositoryInstance = Activator.CreateInstance(repositoryType, _dbContext);

                _produtWarehouseRepository.Add(type, repositoryInstance);
            }

            return (IProductWarehouseRepository)_produtWarehouseRepository[type];
        }

        public Task Rollback()
		{
			_dbContext.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
			return Task.CompletedTask;
		}

		public async Task<int> Save(CancellationToken cancellationToken)
		{
			return await _dbContext.SaveChangesAsync(cancellationToken);
		}

		public Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
			{
				if (disposing)
				{
					//dispose managed resources
					_dbContext.Dispose();
				}
			}
			//dispose unmanaged resources
			disposed = true;
		}
	}
}
