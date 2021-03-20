using System;
using System.Collections.Generic;
using System.Text;
using Fyre.Console.Controller;
using Fyre.Console.Data;
using Fyre.Console.Functions;
using Fyre.Console.Interface;
using Fyre.Console.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using TextToAsciiArt;

namespace Fyre.Console
{
    /// <summary>
    /// The class initiated on startup.
    /// </summary>
    public class Startup : IStartup
    {
        public readonly ILogger<Startup> Log;
        private readonly IConfiguration Configuration;
        public Startup(ILogger<Startup> log, IConfiguration configuration)
        {
            Log = log;
            Configuration = configuration;
        }

        public void Run()
        {
            Log.LogInformation("Welcome to Fyre!\n");

            IArtWriter writer = new ArtWriter();

            var data = writer.WriteString("FYRE");
            System.Console.WriteLine(data);

            Introduction();
        }

        public static void Introduction()
        {
            System.Console.WriteLine("Type 'help' for a list of available commands!");
            System.Console.WriteLine("Please enter a command...");
            ChooseCommand(System.Console.ReadLine());
        }

        /// <summary>
        /// Choose a command
        /// </summary>
        /// <param name="input">The users input.</param>
        public static void ChooseCommand(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                Print.Color("red", "You must enter a command.");
                Introduction();
            }
            else
            {
                switch (input)
                {
                    case "view all":
                        ListController.ViewAll();
                        Introduction();
                        break;
                    case "create list":
                        ListController.Create();
                        Introduction();
                        break;
                    case "help":
                        Command.HelpCommand.ShowHomeCommands();
                        Introduction();
                        break;
                    case "create website":
                        Command.CreateWebsite.Execute();
                        Introduction();
                        break;
                    case "get news":
                        Command.ScraperNews.Execute();
                        Introduction();
                        break;
                    default:
                        Navigate(input);
                        break;
                }
            }
        }

        /// <summary>
        /// Navigate from the home view.
        /// </summary>
        /// <param name="input"></param>
        public static void Navigate(string input)
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
            Introduction();
        }
    }
}
