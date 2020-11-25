using Bookeasy.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Bookeasy.Domain.Entities
{
    public class BusinessUser : Document, IIdentity
    {
        public string BusinessName { get; set; }
        public string Email { get; set; }
        public DateTime LastAccessDate { get; set; } = DateTime.UtcNow;
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
