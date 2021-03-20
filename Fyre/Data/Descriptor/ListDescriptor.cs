using System;
using System.Runtime.Serialization;

namespace Fyre.Console.Data.Descriptor
{
    /// <summary>
    /// The descriptor for the List items.
    /// </summary>
    [DataContract]
    public class ListDescriptor
    {
        [DataMember]
        public int ListId;
        [DataMember]
        public string Title;
        [DataMember]
        public DateTime CreatedDateTime;
        [DataMember]
        public bool Archived;
    }
}
