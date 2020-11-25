using Bookeasy.Domain.Entities;
using System.Collections.Generic;

namespace Bookeasy.Domain.Interfaces
{
    public interface IIdentity
    {
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
