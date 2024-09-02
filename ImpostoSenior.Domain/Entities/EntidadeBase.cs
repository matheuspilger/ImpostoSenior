using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ImpostoSenior.Domain.Entities
{
    public abstract class EntidadeBase
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        public string? Referencia { get; set; }

        public void SetId(ObjectId id) => Id = id;

        public EntidadeBase SetReferencia(string referencia)
        {
            Referencia = referencia;
            return this;
        }
    }
}
