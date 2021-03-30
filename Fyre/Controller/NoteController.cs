using System;
using System.Collections.Generic;
using System.Text;
using Fyre.Console.Data.Descriptor;
using Fyre.Console.Functions;
using Fyre.Console.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Fyre.Console.Controller
{
    /// <summary>
    /// Controller actions for Notes.
    /// </summary>
    public class NoteController
    {
        private readonly ILogger<NoteController> Log;
        private readonly IConfiguration Configuration;
        public NoteController(ILogger<NoteController> log, IConfiguration configuration)
        {
            Log = log;
            Configuration = configuration;
        }

        /// <summary>
        /// Display the information about a specified note.
        /// </summary>
        /// <param name="note">The note in focus.</param>
        public static void Index(ListDescriptor list, NoteDescriptor note)
        {
            System.Console.WriteLine(">>> >>> Welcome to note: [" + note.NoteId + "]");

            System.Console.WriteLine(">>> >>> Type 'help' for a list of available commands!");
            System.Console.WriteLine(">>> >>> Please enter a command...");

            ChooseCommand(System.Console.ReadLine(), list, note);;
        }

        /// <summary>
        /// Choose a command
        /// </summary>
        /// <param name="input">The users input.</param>
        public static void ChooseCommand(string input, ListDescriptor list, NoteDescriptor note)
        {
            if (string.IsNullOrEmpty(input))
            {
                Print.Color("red", "You must enter a command.");
                Index(list, note);
            }
            else
            {
                switch (input)
                {
                    case "view all":
                        ViewAll(list);
                        Index(list, note);
                        break;
                    case "create note":
                        Create(note.ListId);
                        Index(list, note);
                        break;
                    case "help":
                        Command.HelpCommand.ShowListCommands();
                        Index(list, note);
                        break;
                    default:
                        Navigate(input, list, note);
                        break;
                }
            }
        }

        /// <summary>
        /// Navigate around the notes view.
        /// </summary>
        /// <param name="input"></param>
        public static void Navigate(string input, ListDescriptor list, NoteDescriptor note)
        {
            if (input.Contains("view") && !input.Contains("view all") && !string.IsNullOrEmpty(input))
            {
                try
                {
                    var listTitle = input.Split("view ")[1].Trim();
                    ListController.Display(listTitle);
                }
                catch (Exception e)
                {
                    Print.Color("red", e.ToString());
                    Print.Color("red", "Please specify which list to navigate to.");
                }
            }
            Index(list, note);
        }

        /// <summary>
        /// Display the information about a specified note.
        /// </summary>
        /// <param name="id">The id of the note.</param>
        public static void Display(int id)
        {
            System.Console.WriteLine(">>> >>> Here is your note:");

            var note = NoteRepository.ReadNoteDetailsById(id);
            Print.Color("blue", "----------------------------------------------------------------");
            Print.Color("blue", "\n>>> >>> " + note.CreatedDateTime + " | ID: " + note.ListId + 
                                 "\n>>> >>> " + note.Content + "\n");
            Print.Color("blue", "----------------------------------------------------------------");

            Startup.Introduction();
        }

        /// <summary>
        /// View all your notes in the list.
        /// </summary>
        public static void ViewAll(ListDescriptor thisList)
        {
            System.Console.WriteLine(">>> >>> Here are your notes:");

            var lists = NoteRepository.ReadAllNotesInList(thisList.ListId);

            var cacheDate = "";
            foreach (var list in lists)
            {
                var date = Helper.GetDate(list.CreatedDateTime);

                if (date != cacheDate)
                {
                    System.Console.WriteLine("\n > " + date);
                }
                if (list.ListId == thisList.ListId)
                {

                    Print.Color("orange", "\n > " + list.NoteId);
                    Print.Color("blue", list.Content);
                }
            }

            Print.Color("orange", "\n");

            ListController.Index(thisList);

        }

        /// <summary>
        /// Create a new note.
        /// </summary>
        public static void Create(int listId)
        {
            System.Console.WriteLine(">>> >>> Compose your note:");

            var input = System.Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                NoteRepository.CreateNote(input, listId);
            }
        }
    }
}
