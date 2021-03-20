using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fyre.Console.Data;
using Fyre.Console.Data.Descriptor;
using Fyre.Console.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Fyre.Console.Repository
{
    /// <summary>
    /// CRUD operations for the 'Note' table.
    /// </summary>
    public class NoteRepository
    {
        /// <summary>
        /// Create a new note.
        /// </summary>
        /// <param name="title">The name of the note.</param>
        public static void CreateNote(string title, int listId)
        {
            using var context = new Context();

            var note = new Note()
            {
                Content = title,
                Archived = false,
                CreatedDateTime = DateTime.Now,
                ListId = listId
            };

            context.Notes.Add(note);
            context.SaveChanges();
        }

        /// <summary>
        /// Reads a note by Id.
        /// </summary>
        /// <param name="id">The id of the note to view.</param>
        public static NoteDescriptor ReadNoteDetailsById(int id)
        {
            using var context = new Context();

            var note = context.Notes
                .FirstOrDefault(l => l.NoteId == id && l.Archived == false);

            if (note == null) return new NoteDescriptor();

            var noteDescriptor = new NoteDescriptor()
            {
                NoteId = note.NoteId,
                Content = note.Content,
                CreatedDateTime = note.CreatedDateTime
            };

            return noteDescriptor;
        }

        /// <summary>
        /// Reads all Notes in the given list.
        /// </summary>
        public static List<NoteDescriptor> ReadAllNotesInList(int listId)
        {
            using var context = new Context();

            var notes = context.Notes;

            if (notes.ToList().Count < 1) return new List<NoteDescriptor>();

            return notes.Select(note => new NoteDescriptor()
            {
                NoteId = note.NoteId, 
                ListId = note.ListId,
                Content = note.Content, 
                CreatedDateTime = note.CreatedDateTime
            }).ToList();
        }

        /// <summary>
        /// Update the content of a note.
        /// </summary>
        /// <param name="id">The id of the note.</param>
        /// <param name="content">The content of the note.</param>
        public static void UpdateNote(int id, string content)
        {
            using var context = new Context();

            var result = context.Notes.SingleOrDefault(n => n.NoteId == id);

            if (result == null) return;

            result.Content = content;
            context.SaveChanges();
        }

        /// <summary>
        /// Create a new note.
        /// </summary>
        /// <param name="id">The id of the note to delete.</param>
        public static void DeleteList(int id)
        {
            using var context = new Context();

            var result = context.Notes.SingleOrDefault(n => n.NoteId == id);

            if (result == null) return;

            result.Archived = true;
            context.SaveChanges();
        } 
    }
}
