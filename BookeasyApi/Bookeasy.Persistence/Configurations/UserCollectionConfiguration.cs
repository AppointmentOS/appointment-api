using Bookeasy.Domain.Entities;
using MongoDB.Driver;

namespace Bookeasy.Persistence.Configurations
{
    public static class UserCollectionConfiguration
    {
        public static void ConfigureUniqueIndex(IMongoCollection<BusinessUser> collection)
        {
            var keys = Builders<BusinessUser>.IndexKeys
                .Ascending(user => user.Email);

            var indexModel = new CreateIndexModel<BusinessUser>(keys, new CreateIndexOptions { Unique = true });
            collection.Indexes.CreateOne(indexModel);
        }
    }
}
