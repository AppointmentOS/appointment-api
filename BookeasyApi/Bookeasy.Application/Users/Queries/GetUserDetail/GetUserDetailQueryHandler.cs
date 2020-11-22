using AutoMapper;
using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Application.Common.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.Users.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IExtendedRequestHandler<GetUserDetailQuery, UserDto>
    {
        private readonly IIrisDbContext _context;
        private readonly IMapper _mapper;

        public GetUserDetailQueryHandler(IIrisDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CQRSResult<UserDto>> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.BusinessUser.FindByIdAsync(request.UserId);
                return CQRSResult<UserDto>.CreateSuccessResult(_mapper.Map<UserDto>(user));
            }
            catch (Exception e)
            {
                return CQRSResult<UserDto>.CreateFailureResult(e);
            }
        }
    }
}
