using MongoDB.Bson;
using System;

namespace Bookeasy.Domain.Entities
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => Id.CreationTime;
    }
}
