using System;
using MongoDB.Bson.Serialization.Attributes;

namespace BoomFinance
{
	public class Bank: IModel
	{
		[BsonId]
		public string Id { get; set; }
		public string Name { get; set; }
	}
}
