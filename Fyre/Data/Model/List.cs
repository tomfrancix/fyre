using System;
using System.Collections.Generic;
using System.Text;

namespace Fyre.Console.Data.Model
{
    /// <summary>
    /// The model for the List items.
    /// </summary>
    public class List
    {
        public int ListId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public bool Archived { get; set; }
        public List<Note> Notes { get; set; }
    }
}
