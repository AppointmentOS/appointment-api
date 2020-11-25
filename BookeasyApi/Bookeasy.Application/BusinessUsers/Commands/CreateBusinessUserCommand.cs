using Bookeasy.Application.Common.Interfaces;
using Bookeasy.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookeasy.Application.BusinessUsers.Commands
{
    /// <summary>
    /// Create a new business user
    /// </summary>
    public class CreateBusinessUserCommand : IRequest<BusinessUser>
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessName { get; set; }
    }

    public class CreateBusinessUserCommandHandler : IRequestHandler<CreateBusinessUserCommand, BusinessUser>
    {

        public CreateBusinessUserCommandHandler()
        {
        }

        public async Task<BusinessUser> Handle(CreateBusinessUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
