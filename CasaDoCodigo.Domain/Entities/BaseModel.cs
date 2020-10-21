using System.Runtime.Serialization;

namespace CasaDoCodigo.Domain.Entities
{
    [DataContract]
    public class BaseModel
    {
        [DataMember]
        public int Id { get; protected set; }
    }
}
