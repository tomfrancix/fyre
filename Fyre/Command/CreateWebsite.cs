using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Encodings.Web;
using System.Xml;
using Fyre.Console.Data.Descriptor;
using Fyre.Console.Data.Model;
using Fyre.Console.Functions;
using Fyre.Console.Repository;

namespace Fyre.Console.Command
{
    public class CreateWebsite
    {
        public static void Execute()
        {
            Print.Color("yellow", "The new website will be created in: C:\\Source\\Notes\\Websites.");
            var folderPath = "C:\\Source\\Notes\\Websites";

            Print.Color("yellow", "Choose a name for your website:");
            var title = System.Console.ReadLine();

            Print.Color("yellow", "Come up with a catchy tag line...");
            var tagline = System.Console.ReadLine();

            Print.Color("yellow", "Choose a background colour...");
            var backgroundColor = System.Console.ReadLine();
            var color = "black";
            if (backgroundColor.ToLower() != "white" && backgroundColor.ToLower() != "yellow" &&
                backgroundColor.ToLower() != "orange")
            {
                color = "white";
            }

            if (folderPath.EndsWith("/"))
            {
                folderPath = folderPath.Substring(folderPath.Length - 1);
            }

            var path = folderPath + "/" + title;

            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    System.Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                var di = Directory.CreateDirectory(path);
                System.Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                System.Console.WriteLine("The process failed: {0}", e.ToString());
            }

            var indexFileName = path + "/index.html";
            var blogFileName = path + "/blog.html";
            var styleFileName = path + "/style.css";
            var aboutFileName = path + "/about.html";
            var contactFileName = path + "/contact.html";
            try
            {
                // Create the file, or overwrite if the file exists.
                using (var i = File.CreateText(indexFileName))
                {
                    i.WriteLine("<!DOCTYPE html>");
                    i.WriteLine("<html>");
                    i.WriteLine("<head>");
                    i.WriteLine("   <meta http-equiv='content-type' content='text/html;charset=windows-1252'>");
                    i.WriteLine("   <title>" + title + "</title>");
                    i.WriteLine("   <link rel='stylesheet' type='text/css' href='style.css'>");
                    i.WriteLine("   <link href='https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css' rel='stylesheet'>");
                    i.WriteLine(
                        "   <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl' crossorigin='anonymous'>");
                    i.WriteLine(
                        "   <script src='https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js' integrity='sha384-b5kHyXgcpbZJO/tY9Ul7kGkf1S0CWuKcCD38l8YkeH8z8QjE0GmW1gYU5S9FOnJ0' crossorigin='anonymous'></script>");
                    i.WriteLine("</head>");
                    i.WriteLine("<body class='main-body'>");
                    i.WriteLine("   <nav class='navbar navbar-expand-md bg-dark navbar-dark' style='padding-left:10px;'>");
                    i.WriteLine("       <a class='navbar-brand' href='index.html'><i class='fa fa-bolt' style='color:orange;'></i> " + title +"</a>");
                    i.WriteLine(
                        "       <button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#collapsibleNavbar'>");
                    i.WriteLine("           <span class='navbar-toggler-icon'></span>");
                    i.WriteLine("       </button>");
                    i.WriteLine("       <div class='collapse navbar-collapse' id='collapsibleNavbar'>");
                    i.WriteLine("           <ul class='navbar-nav'>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link' href='blog.html'><i class='fa fa-pencil'></i> Blog</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link' href='about.html'><i class='fa fa-info'></i> About</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link' href='contact.html'><i class='fa fa-comment'></i> Contact</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("           </ul>");
                    i.WriteLine("       </div>");
                    i.WriteLine("   </nav>");
                    i.WriteLine("   <div class='container-fluid'>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <div class='col-md-12' style='padding:20px;'>");
                    i.WriteLine("               <div class='jumbotron' style='text-align:center;'>");
                    i.WriteLine("                   <h1>" + title + "</h1>");
                    i.WriteLine("                   <span>" + tagline + "</span>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("           <br/>");
                    i.WriteLine("       </div>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <div class='col'>");
                    i.WriteLine("               <div class='card'>");
                    i.WriteLine("                   <div class='card-body'>");
                    i.WriteLine("                       <h4 class='card-title'>Your Brand New Website</h4>");
                    i.WriteLine(
                        "                       <p class='card-text'>Building a website has never been easier.</p>");
                    i.WriteLine("                       <a href='/about.html' class='card-link'>Find out more!</a>");
                    i.WriteLine("                   </div>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("           <div class='col'>");
                    i.WriteLine("               <div class='card'>");
                    i.WriteLine("                   <div class='card-body'>");
                    i.WriteLine("                       <h4 class='card-title'>All Your Stuff In One Place</h4>");
                    i.WriteLine("                       <p class='card-text'>Organize ideas easily.</p>");
                    i.WriteLine("                       <a href='/about.html' class='card-link'>Find out more!</a>");
                    i.WriteLine("                   </div>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("           <div class='col'>");
                    i.WriteLine("               <div class='card'>");
                    i.WriteLine("                   <div class='card-body'>");
                    i.WriteLine("                       <h4 class='card-title'>Contact Us</h4>");
                    i.WriteLine("                       <p class='card-text'>We would love to hear your feedback.</p>");
                    i.WriteLine("                       <a href='/contact.html' class='card-link'>Contact us</a>");
                    i.WriteLine("                   </div>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("       </div>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <br/>");
                    i.WriteLine("           <div class='col'>");
                    i.WriteLine("               <div class='card'>");
                    i.WriteLine("                   <div class='card-body'>");
                    i.WriteLine("                       <footer>");
                    i.WriteLine("                           <h2 class='card-title'>Footer...</h2>");
                    i.WriteLine("                       </footer>");
                    i.WriteLine("                   </div>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("       </div>");
                    i.WriteLine("   </div>");
                    i.WriteLine("</body>");
                    i.WriteLine("</html>");
                }

                using (var i = File.CreateText(aboutFileName))
                {
                    i.WriteLine("<!DOCTYPE html>");
                    i.WriteLine("<html>");
                    i.WriteLine("<head>");
                    i.WriteLine("   <meta http-equiv='content-type' content='text/html;charset=windows-1252'>");
                    i.WriteLine("   <title>" + title + " - About</title>");
                    i.WriteLine("   <link rel='stylesheet' type='text/css' href='style.css'>");
                    i.WriteLine("   <link href='https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css' rel='stylesheet'>");
                    i.WriteLine(
                        "   <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl' crossorigin='anonymous'>");
                    i.WriteLine(
                        "   <script src='https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js' integrity='sha384-b5kHyXgcpbZJO/tY9Ul7kGkf1S0CWuKcCD38l8YkeH8z8QjE0GmW1gYU5S9FOnJ0' crossorigin='anonymous'></script>");
                    i.WriteLine("</head>");
                    i.WriteLine("<body class='main-body'>");
                    i.WriteLine("   <nav class='navbar navbar-expand-md bg-dark navbar-dark' style='padding-left:10px;'>");
                    i.WriteLine("       <a class='navbar-brand' href='index.html'><i class='fa fa-bolt' style='color:orange;'></i> " + title + "</a>");
                    i.WriteLine(
                        "       <button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#collapsibleNavbar'>");
                    i.WriteLine("           <span class='navbar-toggler-icon'></span>");
                    i.WriteLine("       </button>");
                    i.WriteLine("       <div class='collapse navbar-collapse' id='collapsibleNavbar'>");
                    i.WriteLine("           <ul class='navbar-nav'>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link' href='blog.html'><i class='fa fa-pencil'></i> Blog</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link active' href='about.html'><i class='fa fa-info'></i> About</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link' href='contact.html'><i class='fa fa-comment'></i> Contact</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("           </ul>");
                    i.WriteLine("       </div>");
                    i.WriteLine("   </nav>");
                    i.WriteLine("   <div class='container-fluid'>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <div class='col-md-12' style='padding:20px;'>");
                    i.WriteLine("               <div class='jumbotron' style='text-align:center;'>");
                    i.WriteLine("                   <h1>About Us</h1>");
                    i.WriteLine("                   <span>" + tagline + "</span>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("           <br/>");
                    i.WriteLine("       </div>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <div class='col'>");
                    i.WriteLine("               <div class='card'>");
                    i.WriteLine("                   <div class='card-body'>");
                    i.WriteLine("                       <h4 class='card-title'>Your New About Section!</h4>");
                    i.WriteLine(
                        "                       <p class='card-text'>Just write a bit about who you are...</p>");
                    i.WriteLine("                   </div>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("       </div>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <br/>");
                    i.WriteLine("           <div class='col'>");
                    i.WriteLine("               <div class='card'>");
                    i.WriteLine("                   <div class='card-body'>");
                    i.WriteLine("                       <footer>");
                    i.WriteLine("                           <h2 class='card-title'>Footer...</h2>");
                    i.WriteLine("                       </footer>");
                    i.WriteLine("                   </div>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("       </div>");
                    i.WriteLine("   </div>");
                    i.WriteLine("</body>");
                    i.WriteLine("</html>");
                }

                using (var i = File.CreateText(contactFileName))
                {
                    i.WriteLine("<!DOCTYPE html>");
                    i.WriteLine("<html>");
                    i.WriteLine("<head>");
                    i.WriteLine("   <meta http-equiv='content-type' content='text/html;charset=windows-1252'>");
                    i.WriteLine("   <title>" + title + " - Contact</title>");
                    i.WriteLine("   <link rel='stylesheet' type='text/css' href='style.css'>");
                    i.WriteLine("   <link href='https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css' rel='stylesheet'>");
                    i.WriteLine(
                        "   <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl' crossorigin='anonymous'>");
                    i.WriteLine(
                        "   <script src='https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js' integrity='sha384-b5kHyXgcpbZJO/tY9Ul7kGkf1S0CWuKcCD38l8YkeH8z8QjE0GmW1gYU5S9FOnJ0' crossorigin='anonymous'></script>");
                    i.WriteLine("</head>");
                    i.WriteLine("<body class='main-body'>");
                    i.WriteLine("   <nav class='navbar navbar-expand-md bg-dark navbar-dark' style='padding-left:10px;'>");
                    i.WriteLine("       <a class='navbar-brand' href='index.html'><i class='fa fa-bolt' style='color:orange;'></i> " + title + "</a>");
                    i.WriteLine(
                        "       <button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#collapsibleNavbar'>");
                    i.WriteLine("           <span class='navbar-toggler-icon'></span>");
                    i.WriteLine("       </button>");
                    i.WriteLine("       <div class='collapse navbar-collapse' id='collapsibleNavbar'>");
                    i.WriteLine("           <ul class='navbar-nav'>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link' href='blog.html'><i class='fa fa-pencil'></i> Blog</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link' href='about.html'><i class='fa fa-info'></i> About</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link active' href='contact.html'><i class='fa fa-comment'></i> Contact</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("           </ul>");
                    i.WriteLine("       </div>");
                    i.WriteLine("   </nav>");
                    i.WriteLine("   <div class='container-fluid'>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <div class='col-md-12' style='padding:20px;'>");
                    i.WriteLine("               <div class='jumbotron' style='text-align:center;'>");
                    i.WriteLine("                   <h1>Contact Us</h1>");
                    i.WriteLine("                   <span>" + tagline + "</span>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("           <br/>");
                    i.WriteLine("       </div>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <div class='col'>");
                    i.WriteLine("               <div class='card'>");
                    i.WriteLine("                   <div class='card-body'>");
                    i.WriteLine("                       <h4 class='card-title'>Your New Contact Section!</h4>");
                    i.WriteLine(
                        "                       <p class='card-text'>Address:</p>");
                    i.WriteLine(
                        "                       <p class='card-text'>Phone:</p>");
                    i.WriteLine(
                        "                       <p class='card-text'>Email:</p>");
                    i.WriteLine("                   </div>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("       </div>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <br/>");
                    i.WriteLine("           <div class='col'>");
                    i.WriteLine("               <div class='card'>");
                    i.WriteLine("                   <div class='card-body'>");
                    i.WriteLine("                       <footer>");
                    i.WriteLine("                           <h2 class='card-title'>Footer...</h2>");
                    i.WriteLine("                       </footer>");
                    i.WriteLine("                   </div>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("       </div>");
                    i.WriteLine("   </div>");
                    i.WriteLine("</body>");
                    i.WriteLine("</html>");
                }

                using (var i = File.CreateText(blogFileName))
                {
                    i.WriteLine("<!DOCTYPE html>");
                    i.WriteLine("<html>");
                    i.WriteLine("<head>");
                    i.WriteLine("   <meta http-equiv='content-type' content='text/html;charset=windows-1252'>");
                    i.WriteLine("   <title>" + title + " - Contact</title>");
                    i.WriteLine("   <link rel='stylesheet' type='text/css' href='style.css'>");
                    i.WriteLine("   <link href='https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css' rel='stylesheet'>");
                    i.WriteLine(
                        "   <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-BmbxuPwQa2lc/FVzBcNJ7UAyJxM6wuqIj61tLrc4wSX0szH/Ev+nYRRuWlolflfl' crossorigin='anonymous'>");
                    i.WriteLine(
                        "   <script src='https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta2/dist/js/bootstrap.bundle.min.js' integrity='sha384-b5kHyXgcpbZJO/tY9Ul7kGkf1S0CWuKcCD38l8YkeH8z8QjE0GmW1gYU5S9FOnJ0' crossorigin='anonymous'></script>");
                    i.WriteLine("</head>");
                    i.WriteLine("<body class='main-body'>");
                    i.WriteLine("   <nav class='navbar navbar-expand-md bg-dark navbar-dark' style='padding-left:10px;'>");
                    i.WriteLine("       <a class='navbar-brand' href='index.html'><i class='fa fa-bolt' style='color:orange;'></i> " + title + "</a>");
                    i.WriteLine(
                        "       <button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#collapsibleNavbar'>");
                    i.WriteLine("           <span class='navbar-toggler-icon'></span>");
                    i.WriteLine("       </button>");
                    i.WriteLine("       <div class='collapse navbar-collapse' id='collapsibleNavbar'>");
                    i.WriteLine("           <ul class='navbar-nav'>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link active' href='blog.html'><i class='fa fa-pencil'></i> Blog</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link' href='about.html'><i class='fa fa-info'></i> About</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("               <li class='nav-item'>");
                    i.WriteLine("                   <a class='nav-link' href='contact.html'><i class='fa fa-comment'></i> Contact</a>");
                    i.WriteLine("               </li>");
                    i.WriteLine("           </ul>");
                    i.WriteLine("       </div>");
                    i.WriteLine("   </nav>");
                    i.WriteLine("   <div class='container-fluid'>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <div class='col-md-12' style='padding:20px;'>");
                    i.WriteLine("               <div class='jumbotron' style='text-align:center;'>");
                    i.WriteLine("                   <h1>Blog</h1>");
                    i.WriteLine("                   <span>" + tagline + "</span>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("           <br/>");
                    i.WriteLine("       </div>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <div class='col'>");
                    i.WriteLine("               <div class='card'>");
                    i.WriteLine("                   <div class='card-body'>");
                    i.WriteLine("                       <h4 class='card-title'>Your New Blog Section!</h4>");
                    i.WriteLine("                   </div>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("       </div>");
                    i.WriteLine("       <div class='row'>");
                    i.WriteLine("           <br/>");
                    i.WriteLine("           <div class='col'>");
                    i.WriteLine("               <div class='card'>");
                    i.WriteLine("                   <div class='card-body'>");
                    i.WriteLine("                       <footer>");
                    i.WriteLine("                           <h2 class='card-title'>Footer...</h2>");
                    i.WriteLine("                       </footer>");
                    i.WriteLine("                   </div>");
                    i.WriteLine("               </div>");
                    i.WriteLine("           </div>");
                    i.WriteLine("       </div>");
                    i.WriteLine("   </div>");
                    i.WriteLine("</body>");
                    i.WriteLine("</html>");
                }

                using (var i = File.CreateText(styleFileName))
                {
                    i.WriteLine("@import url('https://fonts.googleapis.com/css2?family=Roboto:wght@100&display=swap');");
                    i.WriteLine(".main-body {font-family: 'Roboto', sans-serif;background-color: "+backgroundColor+";color:"+color+";}");
                    i.WriteLine("h1 { font-weight:bold !important;margin-top:10px; }");
                    i.WriteLine("div.card { background-color:rgba(255,255,255,0.2) !important;}");
                    i.WriteLine("div.jumbotron { background-color:rgba(200,200,200,0.2) !important;padding:20px;}");
                }
            }
            catch
            {
                Print.Color("red", "Failed to create website!");
            }
        }
    }
}
