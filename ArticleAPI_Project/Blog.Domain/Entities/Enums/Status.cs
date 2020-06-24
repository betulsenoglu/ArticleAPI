using System.Runtime.Serialization;

namespace Blog.Domain.Entities.Enums
{
    #region Enumerations

    /// <summary>
    ///  Content Statuses
    /// </summary>
    [DataContract]
    public enum Status
    {
        [EnumMember] Active = 0,

        [EnumMember] Passive = 1,

        [EnumMember] Deleted = 2,

        [EnumMember] Draft = 4,
    }

    #endregion Enumerations
}