using MongoDB.Driver;
using OrderWebApi.Application.Interfaces;

namespace OrderWebApi.Infrastructure.Repositories
{
    public class MongoDatabaseService : IMongoDatabaseService
    {
        public IMongoDatabase GetDatabase()
        {
            var connectionString = $"mongodb://user:pass@host/dms_order?authSource=admin";
            var mongoUrl = MongoUrl.Create(connectionString);
            var mongoClient = new MongoClient(mongoUrl);
            return mongoClient.GetDatabase("dms_order");
        }
    }
}
