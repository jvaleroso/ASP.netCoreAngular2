using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;

namespace BoomFinance.Core.Repository
{
	public interface IRepository<T> where T : class
	{
		Task<List<T>> GetListAsync();
		Task<T> FindOneAsync(string id);
		Task AddAsync(T entity);
		Task<DeleteResult> DeleteAsync(string id);
		Task<ReplaceOneResult> UpdateAsync(string id, T entity);
	}
}
