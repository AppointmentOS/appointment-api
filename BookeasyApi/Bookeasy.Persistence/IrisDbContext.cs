using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Domain.Entities;
using Bookeasy.Persistence.Collections;
using MongoDB.Driver;

namespace Bookeasy.Persistence
{
    public class IrisDbContext : IIrisDbContext
    {
        public IBusinessUserRepository BusinessUser { get; }

        public IrisDbContext(IMongoDbDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.Database);
            BusinessUser = new BusinessUserRepository(db.GetCollection<BusinessUser>(settings.UserCollection));
        }
    }
}
