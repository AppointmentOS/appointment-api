using Bookeasy.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface IBusinessUserRepository : IMongoRepository<BusinessUser>
    {
    }
}
