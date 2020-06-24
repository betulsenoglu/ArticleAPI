using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Blog.Domain.Entities.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Domain.Entities
{
    public class BaseEntity
    {
        /// <summary>
        ///  Primary Key and Object Id
        /// </summary>
        [BsonId]
        [DataMember]
        [BsonIgnoreIfDefault]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string _Id { get; set; }
        
        /// <summary>
        ///  Updated Date
        /// </summary>
        [DataMember]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public virtual Status Status { get; set; }
        
        /// <summary>
        ///  Updated Date
        /// </summary>
        [DataMember]
        [BsonIgnoreIfDefault]
        public virtual DateTime? UpdatedDate { get; set; }
        
        /// <summary>
        ///  Creation Date
        /// </summary>
        [DataMember]
        [BsonIgnoreIfDefault]
        public virtual DateTime CreatedDate { get; set; }
        
    }
}