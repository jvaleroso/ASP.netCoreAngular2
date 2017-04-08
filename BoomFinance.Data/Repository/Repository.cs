using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System;

namespace BoomFinance.Data.Repository
{
	public class Repository<T> : IRepository<T> where T : class, IModel
	{
		readonly FinanceMongoContext<T> _dbContext;

		public Repository(IOptions<Settings> settings)
		{
			_dbContext = new FinanceMongoContext<T>(settings);
		}

		public Task Add(T entity)
		{
			if (string.IsNullOrEmpty(entity.Id))
			{
				entity.Id = Guid.NewGuid().ToString();
			}
			return _dbContext.Collection.InsertOneAsync(entity);
		}

		public Task<DeleteResult> Delete(string id)
		{
			return _dbContext.Collection.DeleteOneAsync(Builders<T>.Filter.Eq(s => s.Id, id));
		}

		public Task<T> FindOne(string id)
		{
			return _dbContext.Collection.Find(Builders<T>.Filter.Eq(t => t.Id, id)).FirstOrDefaultAsync();
		}

		public Task<List<T>> GetListAsync()
		{
			return _dbContext.Collection.Find(_ => true).ToListAsync();
		}

		public Task<ReplaceOneResult> Update(string id, T entity)
		{
			return _dbContext.Collection.ReplaceOneAsync(t => t.Id == id, entity, new UpdateOptions { IsUpsert = true });
		}
	}
}
