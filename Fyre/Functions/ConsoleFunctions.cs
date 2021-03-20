using System;
using System.Collections.Generic;
using System.Text;

namespace Fyre.Console.Functions
{
    public class Print
    {
        public static void Color(string color, string content)
        {
            switch (color)
            {
                case "green":
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine(content);
                    break;

                case "blue":
                    System.Console.ForegroundColor = ConsoleColor.Cyan;
                    System.Console.WriteLine(content);
                    break;

                case "red":
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine(content);
                    break;

                case "orange":
                    System.Console.ForegroundColor = ConsoleColor.DarkYellow;
                    System.Console.WriteLine(content);
                    break;

                case "yellow":
                    System.Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine(content);
                    break;

                case "grey":
                    System.Console.ForegroundColor = ConsoleColor.Gray;
                    System.Console.WriteLine(content);
                    break; 
                default:
                    System.Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
