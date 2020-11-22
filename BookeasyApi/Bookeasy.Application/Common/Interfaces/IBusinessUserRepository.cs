using System.Collections.Generic;
using System.Threading.Tasks;
using Bookeasy.Domain.Entities;

namespace Bookeasy.Application.Common.Interfaces
{
    public interface IBusinessUserRepository : IMongoRepository<BusinessUser>
    {
    }
}
