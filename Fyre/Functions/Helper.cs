using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using Newtonsoft.Json.Schema;

namespace Fyre.Console.Functions
{
    public class Helper
    {
        /// <summary>
        /// A method for returning a formatted date.
        /// </summary>
        /// <param name="datetime">The datetime.</param>
        /// <returns>The formatted date.</returns>
        public static string GetDate(DateTime datetime)
        {
            var month = "";
            switch (datetime.Month)
            {
                case 1:
                    month = "January";
                    break;
                case 2:
                    month = "February";
                    break;
                case 3:
                    month = "March";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "May";
                    break;
                case 6:
                    month = "June";
                    break;
                case 7:
                    month = "July";
                    break;
                case 8:
                    month = "August";
                    break;
                case 9:
                    month = "September";
                    break;
                case 10:
                    month = "October";
                    break;
                case 11:
                    month = "November";
                    break;
                default:
                    month = "December";
                    break;
            }

            var day = "";
            if (datetime.Day == 1 || datetime.Day == 21 || datetime.Day == 31)
            {
                day = datetime.Day + "st";
            } 
            else if (datetime.Day == 2 || datetime.Day == 22)
            {
                day = datetime.Day + "nd";
            }
            else if (datetime.Day == 3 || datetime.Day == 23)
            {
                day = datetime.Day + "rd";
            }
            else if ((datetime.Day >= 4 && datetime.Day <= 20) || (datetime.Day >= 24 && datetime.Day <= 30))
            {
                day = datetime.Day + "th";
            }

            var date = day + " of " + month + ", " + datetime.Year;

            return date;
        }

        /// <summary>
        /// A method for returning a formatted time.
        /// </summary>
        /// <param name="datetime">The datetime.</param>
        /// <returns>The formatted time.</returns>
        public static string GetTime(DateTime datetime)
        {
            var time = "";

            time = datetime.Hour + ":" + datetime.Minute;

            return time;
        }
    }
}
