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
    /// Controller actions for Lists.
    /// </summary>
    public class ListController
    {
        private readonly ILogger<ListController> Log;
        private readonly IConfiguration Configuration;
        public ListController(ILogger<ListController> log, IConfiguration configuration)
        {
            Log = log;
            Configuration = configuration;
        }

        /// <summary>
        /// Display the information about a specified list.
        /// </summary>
        /// <param name="list">The list in focus.</param>
        public static void Index(ListDescriptor list)
        {
            System.Console.WriteLine(">>> Welcome to [" + list.Title + "]");

            System.Console.WriteLine(">>> Type 'help' for a list of available commands!");
            System.Console.WriteLine(">>> Please enter a command...");

            ChooseCommand(System.Console.ReadLine(), list);
        }

        /// <summary>
        /// Display the information about a specified list.
        /// </summary>
        /// <param name="title">The title of the list.</param>
        public static void Display(string title)
        {
            System.Console.WriteLine(">>> Here is your list:");

            var list = ListRepository.ReadListDetailsByTitle(title);
            Print.Color("green", "----------------------------------------------------------------");
            Print.Color("green", "\n>>> " + list.CreatedDateTime + " | ID: " + list.ListId + " | " +
                               list.Title + "\n");
            Print.Color("green", "----------------------------------------------------------------");
            Index(list);
        }

        /// <summary>
        /// Choose a command.
        /// </summary>
        /// <param name="input">The users input.</param>
        public static void ChooseCommand(string input, ListDescriptor list)
        {
            if (string.IsNullOrEmpty(input))
            {
                Print.Color("red", "You must enter a command.");
                Index(list);
            }
            else
            {
                switch (input)
                {
                    case "view all":
                        NoteController.ViewAll(list);
                        Index(list);
                        break;
                    case "create note":
                        NoteController.Create(list.ListId);
                        Index(list);
                        break;
                    case "help":
                        Command.HelpCommand.ShowListCommands();
                        Index(list);
                        break;
                    case "export all":
                        Command.ExportCommand.Export(list);
                        Index(list);
                        break;
                    case "back":
                        Print.Color("Yellow", "Redirecting to home...");
                        Startup.Introduction();
                        break;
                    default:
                        Navigate(input, list);
                        break;
                }
            }
        }

        /// <summary>
        /// Navigate around the notes view.
        /// </summary>
        /// <param name="input">The user input.</param>
        /// <param name="list">The current list in focus.</param>
        public static void Navigate(string input, ListDescriptor list)
        {
            if (input.Contains("view") && !input.Contains("view all") && !string.IsNullOrEmpty(input))
            {
                try
                {
                    var noteId = Convert.ToInt32(input.Split("view ")[1].Trim());
                    NoteController.Display(noteId);
                }
                catch (Exception e)
                {
                    Print.Color("red", e.ToString());
                    Print.Color("red", "Please specify which list to navigate to.");
                }
            }
            Index(list);
        }

        /// <summary>
        /// View all your lists.
        /// </summary>
        public static void ViewAll()
        {
            System.Console.WriteLine("Here are your lists:");

            var lists = ListRepository.ReadAll();

            foreach (var list in lists)
            {
                Print.Color("green", "\n" + list.CreatedDateTime + " | ID: " + list.ListId + " | " +
                                         list.Title + "\n");
            }

            Startup.Introduction();

        }

        /// <summary>
        /// Create a new list.
        /// </summary>
        public static void Create()
        {
            System.Console.WriteLine("Enter the title of your list:");

            var input = System.Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                ListRepository.CreateList(input);
            }
        }
    }
}
