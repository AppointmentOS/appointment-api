using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Bookeasy.Domain.Entities
{
    public class RefreshToken : Document
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        [BsonIgnore]
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        [BsonIgnore]
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
