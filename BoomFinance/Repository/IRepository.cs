using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MongoDB.Driver;

namespace BoomFinance
{
	public interface IRepository<T> where T : class
	{
		Task<List<T>> GetListAsync();
		Task<T> FindOne(string id);
		Task Add(T entity);
		Task<DeleteResult> Delete(string id);
		Task<ReplaceOneResult> Update(string id, T entity);
	}
}
