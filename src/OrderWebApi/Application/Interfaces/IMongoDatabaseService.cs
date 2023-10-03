using MongoDB.Driver;

namespace OrderWebApi.Application.Interfaces
{
    public interface IMongoDatabaseService
    {
        IMongoDatabase GetDatabase();
    }
}
