using System;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace BoomFinance.Data
{
    public class FinanceMongoContext<T> 
		where T : class
    {
		private readonly IMongoDatabase _database;

		public FinanceMongoContext(IOptions<Settings> settings)
		{
			var client = new MongoClient(settings.Value.ConnectionString);

			if (client != null)
			{
				_database = client.GetDatabase(settings.Value.Database);
			}
		}

		public IMongoCollection<T> Collection
		{
			get
			{
				return _database.GetCollection<T>((typeof(T).Name));
			}
		}
    }
}
