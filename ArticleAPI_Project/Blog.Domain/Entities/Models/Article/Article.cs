using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.Domain.Entities.Models.Article
{
    public class Article : BaseEntity
    {
        #region Properties

        /// <summary>
        /// Title of the Article
        /// </summary>
        [BsonIgnoreIfNull]
        [DataMember]
        public virtual string Title { get; set; }

        /// <summary>
        /// Description of the Article
        /// </summary>
        [BsonIgnoreIfNull]
        [DataMember]
        public virtual string Description { get; set; }

        /// <summary>
        /// Text of the Article
        /// </summary>
        [BsonIgnoreIfNull]
        [DataMember]
        public virtual string Text { get; set; }

        /// <summary>
        /// Url of the Article. Default : Slugified, SEO Friendly Article Title
        /// </summary>
        [BsonIgnoreIfNull]
        [DataMember]
        public virtual string Url { get; set; }

        /// <summary>
        ///  Writers' Names
        /// </summary>
        [BsonIgnoreIfNull]
        [DataMember]
        public virtual IList<string> Writers { get; set; }

        /// <summary>
        ///  Sources of the Article
        /// </summary>
        [BsonIgnoreIfNull]
        [DataMember]
        public virtual IList<string> Sources { get; set; }

        #endregion Properties
    }
}