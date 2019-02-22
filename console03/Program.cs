// The purpose of this program is to learn about the configuration
// system.  This time we want to bind a typed class to the configuration
// file to extract its members in a typed fashion using a POCO, Plain
// Old Class Object.
//
// Needed Extensions:
//      Microsoft.Extensions.Configuration
//      Microsoft.Extensions.Configuration.FileExtensions
//      Microsoft.Extensions.Configuration.Json
//      Microsoft.Extensions.Configuration.Binder

using System;
using System.IO;
using System.Configuration;
using System.Collections;
using static System.Console;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace console03
{
    public class ApplicationSettings {
        public string Name {get; set;} = "";
    }


    class Program
    {
        static void Main(string[] args)
        {
     // Build key/value based configuration settings for use
            // in an application from the json file.
            IConfigurationBuilder builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
            Console.WriteLine("builder is a {0}", builder.GetType().Name);
            // Build the root.
            IConfigurationRoot config = builder.Build();
            Console.WriteLine("config is a {0}", config.GetType().Name);
            // Now bind our POCO AppSetings to the Root.
            var settings = new ApplicationSettings();
            config.Bind("Application", settings);

            WriteLine("Name: {0}", settings.Name);
        }
    }
}
