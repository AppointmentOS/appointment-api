using System;
using MongoDB.Bson;

namespace Bookeasy.Domain.Entities
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => Id.CreationTime;
    }
}
