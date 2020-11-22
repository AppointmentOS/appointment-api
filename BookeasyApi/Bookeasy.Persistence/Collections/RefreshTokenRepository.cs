using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Data.Services;
using Bookeasy.Domain.Entities;
using MongoDB.Driver;

namespace Bookeasy.Persistence.Collections
{
    public class RefreshTokenRepository : CollectionBase<RefreshToken>, IMongoRepository<RefreshToken>
    {
        public RefreshTokenRepository(IMongoCollection<RefreshToken> collection) : base(collection)
        {
        }

        public async Task<IQueryable<RefreshToken>> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RefreshToken>> FilterBy(Expression<Func<RefreshToken, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TProjected>> FilterBy<TProjected>(Expression<Func<RefreshToken, bool>> filterExpression, Expression<Func<RefreshToken, TProjected>> projectionExpression)
        {
            throw new NotImplementedException();
        }

        public async Task<RefreshToken> FindOneAsync(Expression<Func<RefreshToken, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public async Task<RefreshToken> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task InsertOneAsync(RefreshToken document)
        {
            throw new NotImplementedException();
        }

        public async Task InsertManyAsync(ICollection<RefreshToken> documents)
        {
            throw new NotImplementedException();
        }

        public async Task ReplaceOneAsync(RefreshToken document)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateOneAsync(RefreshToken document)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteOneAsync(Expression<Func<RefreshToken, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteManyAsync(Expression<Func<RefreshToken, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }
    }
}
