// The purpose of this program is to learn about the configuration
// system.  Part of it is static so that it can be accessed by all
// of the program. So, we will build part of the system by pointing
// it to our json file and creating the needed object.
//
// Needed Extensions:
//      Microsoft.Extensions.Configuration
//      Microsoft.Extensions.Configuration.FileExtensions
//      Microsoft.Extensions.Configuration.Json

using System;
using System.IO;
using System.Configuration;
using System.Collections;
using static System.Console;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;

namespace console02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build key/value based configuration settings for use
            // in an application from the json file.
            IConfigurationBuilder builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
            // Builds an IConfiguration with keys and values from the
            // set of sources registered in Sources.
            IConfigurationRoot config = builder.Build();
            Console.WriteLine("config is a {0}", config.GetType().Name);
            if (config is IConfigurationRoot) {
                WriteLine("Application Name1: {0}", config["Application:Name"]);
            }

            IConfigurationSection appConfig = config.GetSection("Application");
            WriteLine("Type is: {0}", appConfig.GetType().Name);
            if (appConfig is IConfigurationSection) {
                WriteLine("Application Name2: {0}", appConfig.GetSection("Name").Value);
            }
        }
    }
}
