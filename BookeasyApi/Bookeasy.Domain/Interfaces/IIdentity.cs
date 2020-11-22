using System.Collections.Generic;
using Bookeasy.Domain.Entities;

namespace Bookeasy.Domain.Interfaces
{
    public interface IIdentity
    {
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
