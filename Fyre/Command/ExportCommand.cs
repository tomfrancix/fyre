using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Fyre.Console.Data.Descriptor;
using Fyre.Console.Data.Model;
using Fyre.Console.Functions;
using Fyre.Console.Repository;

namespace Fyre.Console.Command
{
    public class ExportCommand
    {
        public static void Export(ListDescriptor list)
        {
            Print.Color("yellow", "The new file will be created in: C:\\Source\\Notes.");
            var folderPath = "C:\\Source\\Notes";

            Print.Color("yellow", "Choose a name for your file:");
            var fileName = System.Console.ReadLine();

            if (folderPath.EndsWith("/"))
            {
                folderPath = folderPath.Substring(folderPath.Length - 1);
            }

            var path = folderPath + "/" + fileName;

            var notes = NoteRepository.ReadAllNotesInList(list.ListId);

            if (File.Exists(path)) return;

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("List ID: " + list.ListId + ", Created: " + list.CreatedDateTime);
                sw.WriteLine(list.Title.ToUpper());
                sw.WriteLine("----------");

                var cacheDate = "098uio8u";
                var cacheTime = "098uio8u";
                foreach (var note in notes)
                {
                    var formattedDate = Helper.GetDate(note.CreatedDateTime);

                    if (cacheDate == formattedDate)
                    {
                        var formattedTime = Helper.GetTime(note.CreatedDateTime);

                        if (cacheTime == formattedTime)
                        {
                            sw.WriteLine("\n" + note.Content);
                        }
                        else
                        {
                            sw.WriteLine("\n" + formattedTime);
                            sw.WriteLine("\n" + note.Content);
                        }
                    }
                    else
                    {
                        sw.WriteLine("\n" + formattedDate);

                        var time = note.CreatedDateTime.Hour + " : " + note.CreatedDateTime.Minute + " : " + note.CreatedDateTime.Second;
                        sw.WriteLine("\n" + time + "\n" + note.Content);
                    }
                    cacheDate = formattedDate;
                }
            }

            var oldFileName = Path.GetFileName(path);
            var newFileName = Path.ChangeExtension(oldFileName, ".doc");
            var newFilePath = folderPath + "/" + newFileName;
            File.Move(path, newFilePath);
            Print.Color("green", "Export successful!");

        }
    }
}
