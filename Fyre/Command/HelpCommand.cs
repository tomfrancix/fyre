using System;
using System.Collections.Generic;
using System.Text;
using Fyre.Console.Functions;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Serilog;
using Serilog.Core;

namespace Fyre.Console.Command
{
    /// <summary>
    /// Information about the commands available at any given time.
    /// </summary>
    public class HelpCommand
    {
        public static void ShowHomeCommands()
        {

            Print.Color("yellow", "\nBelow is a list of available commands.");
            System.Console.WriteLine("--------------------------------------");

            System.Console.WriteLine("view all         | View all lists.");
            System.Console.WriteLine("view [list name] | Go to list. ");
            System.Console.WriteLine("create list      | Create a new list.");
               Print.Color("orange", "get news         | Scrape news.");
               Print.Color("orange", "get stocks       | Scrape stock values.");
               Print.Color("orange", "create website   | Create a website.\n");
        }

        /// <summary>
        /// A list of the commands available in the List focus.
        /// </summary>
        public static void ShowListCommands()
        {

            Print.Color("yellow", "\nBelow is a list of available commands.");
            System.Console.WriteLine("----------------------------------------------------");

            System.Console.WriteLine("view all         | View all notes in the list.");
            System.Console.WriteLine("view [Note ID]   | Go to a note by ID. ");
            System.Console.WriteLine("create note      | Create a new note.");
            System.Console.WriteLine("delete list      | Delete the current list.");
            System.Console.WriteLine("back             | <<< Go back.");
               Print.Color("orange", "export all       | Export everything to a .txt. file.\n");
        }
    }
}
