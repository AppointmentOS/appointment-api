using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Bookeasy.Domain.Entities
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
