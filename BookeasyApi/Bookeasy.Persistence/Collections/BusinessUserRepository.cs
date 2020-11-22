using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Data.Services;
using Bookeasy.Domain.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Bookeasy.Persistence.Collections
{
    public class BusinessUserRepository : CollectionBase<BusinessUser>, IBusinessUserRepository
    {
        public BusinessUserRepository(IMongoCollection<BusinessUser> collection) : base(collection)
        {
        }

        public async Task<IQueryable<BusinessUser>> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BusinessUser>> FilterBy(Expression<Func<BusinessUser, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TProjected>> FilterBy<TProjected>(Expression<Func<BusinessUser, bool>> filterExpression, Expression<Func<BusinessUser, TProjected>> projectionExpression)
        {
            throw new NotImplementedException();
        }

        public async Task<BusinessUser> FindOneAsync(Expression<Func<BusinessUser, bool>> filterExpression)
        {
            return await (await Collection.FindAsync(filterExpression)).FirstAsync();
        }

        public async Task<BusinessUser> FindByIdAsync(string id)
        {
            return await Collection.Find(user => user.Id == ObjectId.Parse(id)).FirstAsync();
        }

        public async Task InsertOneAsync(BusinessUser document)
        {
            await Collection.InsertOneAsync(document);
        }

        public async Task InsertManyAsync(ICollection<BusinessUser> documents)
        {
            throw new NotImplementedException();
        }

        public async Task ReplaceOneAsync(BusinessUser document)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOneAsync(BusinessUser document)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOneAsync(Expression<Func<BusinessUser, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteManyAsync(Expression<Func<BusinessUser, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}
