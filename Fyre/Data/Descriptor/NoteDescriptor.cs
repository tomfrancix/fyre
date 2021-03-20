using System;
using System.Runtime.Serialization;

namespace Fyre.Console.Data.Descriptor
{
    /// <summary>
    /// The descriptor for the Note items.
    /// </summary>
    [DataContract]
    public class NoteDescriptor
    {
        [DataMember]
        public int NoteId;
        [DataMember]
        public string Content;
        [DataMember]
        public DateTime CreatedDateTime;
        [DataMember]
        public bool Archived;
        [DataMember] 
        public int ListId;
    }
}
