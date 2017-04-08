using System;
using MongoDB.Bson.Serialization.Attributes;

namespace BoomFinance.Core
{
	public class Bank: IModel
	{
		[BsonId]
		public string Id { get; set; }
		public string Name { get; set; }
	}
}
