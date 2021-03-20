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
    /// CRUD operations for the 'List' table.
    /// </summary>
    public class ListRepository
    {
        /// <summary>
        /// Create a new list.
        /// </summary>
        /// <param name="title">The name of the list.</param>
        public static void CreateList(string title)
        {
            using var context = new Context();

            var list = new List()
            {
                Title = title,
                Archived = false
            };

            context.Lists.Add(list);
            context.SaveChanges();
        }

        /// <summary>
        /// Reads a list by Id.
        /// </summary>
        /// <param name="title">The title of the list to view.</param>
        public static ListDescriptor ReadListDetailsByTitle(string title)
        {
            using var context = new Context();

            var list = context.Lists
                .FirstOrDefault(l => l.Title == title && l.Archived == false);

            if (list == null) return new ListDescriptor();

            var listDescriptor = new ListDescriptor()
            {
                ListId = list.ListId,
                Title = list.Title,
                CreatedDateTime = list.CreatedDateTime
            };

            return listDescriptor;
        }

        /// <summary>
        /// Reads all Lists.
        /// </summary>
        public static List<ListDescriptor> ReadAll()
        {
            using var context = new Context();

            var lists = context.Lists;

            if (lists.ToList().Count < 1) return new List<ListDescriptor>();

            return lists.Select(list => new ListDescriptor()
            {
                ListId = list.ListId, 
                Title = list.Title, 
                CreatedDateTime = list.CreatedDateTime
            }).ToList();
        }

        /// <summary>
        /// Update the title of the list.
        /// </summary>
        /// <param name="title">The name of the list.</param>
        public static void UpdateList(string title)
        {
            using var context = new Context();

            var list = new List()
            {
                Title = title
            };

            context.Update(list);
            context.SaveChanges();
        }

        /// <summary>
        /// Create a new list.
        /// </summary>
        /// <param name="id">The id of the list to delete.</param>
        public static void DeleteList(int id)
        {
            using var context = new Context();

            var list = new List()
            {
                Archived = true
            };

            context.Update(list);
            context.SaveChanges();
        } 
    }
}
