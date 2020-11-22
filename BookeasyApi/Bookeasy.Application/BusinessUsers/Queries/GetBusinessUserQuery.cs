using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.BusinessUsers.Queries
{
    public class GetBusinessUserQuery : IRequest<BusinessUser>
    {
        public string UserId { get; set; }

        public GetBusinessUserQuery(string userId)
        {
            UserId = userId;
        }
    }

    public class GetBusinessUserQueryHandler : IRequestHandler<GetBusinessUserQuery, BusinessUser>
    {
        private readonly IIrisDbContext _dbContext;

        public GetBusinessUserQueryHandler(IIrisDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<BusinessUser> Handle(GetBusinessUserQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.BusinessUser.FindByIdAsync(request.UserId);
        }
    }
}
