using System;
using System.Collections.Generic;
using System.Text;

namespace Fyre.Console.Data.Model
{
    /// <summary>
    /// The model for the Note items.
    /// </summary>
    public class Note
    {
        public int NoteId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool Archived { get; set; }

        public int ListId { get; set; }
        public List List { get; set; }
    }
}
