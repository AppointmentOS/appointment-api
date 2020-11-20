using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Domain.Entities;
using Bookeasy.Persistence.Collections;
using MongoDB.Driver;

namespace Bookeasy.Persistence
{
    public class IrisDbContext : IIrisDbContext
    {
        public IUserCollection User { get; }

        public IrisDbContext(IMongoDbDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.Database);
            User = new UserCollection(db.GetCollection<User>(settings.UserCollection));
        }
    }
}
