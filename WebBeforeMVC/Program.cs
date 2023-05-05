using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBeforeMVC
{
    public class Program
    {
        //
        public static int Main()
        {
            Console.WriteLine("App Start");
            //Create Listenr
           var builder= WebApplication.CreateBuilder();
           var app= builder.Build();
         
            #region Before MiddleWare
            app.Run(async _Context =>
            {
                var route = _Context.Request.Path.ToString().ToLower();
                switch (route)
                {
                    case "/":
                    case "/home":
                        await _Context.Response.WriteAsync("<h1 style='color:aqua'>Home Page</h1>" + "<br> <h3>Welcome To My Home Page</h3>"+ "<br> <a href='/home/contact'>contact</a>" + " <a href='/home/aboutus'>Apout Us </a>");
                        break;
                    case "/home/contact":
                        await _Context.Response.WriteAsync("<h1 style='color:aqua'>Contact Page</h1>" + "<br> <h3>Welcome To My Contact Page</h3>" + "<br> <a href='/home/aboutus'>Apout Us </a>" + "<br><h3 style='color:gray'>Back To Home Page</h3> <a href='/home'>Home </a> ");
                        break;
                    case "/home/aboutus":
                        await _Context.Response.WriteAsync("<h1 style='color:aqua'>Apout Us Page</h1>" + "<br> <h3>Welcome To My About Page</h3>" + "<br><h3 style='color:gray'>Back To Home Page</h3> <a href='/home'>Home </a> ");
                        break;

                    default:
                        break;
                }

            });

            #endregion
            app.Run();

            Console.WriteLine("App End");

            return 0;
        }
    }
}
