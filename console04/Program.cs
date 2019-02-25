// The purpose of this program is to learn about accessing data in our
// Docker MS Sql Server using ADO.NET. According to what I read this is
// the hard way to access the data.
//
// Needed Extensions:
//      Microsoft.Extensions.Configuration
//      Microsoft.Extensions.Configuration.FileExtensions
//      Microsoft.Extensions.Configuration.Json
//      Microsoft.Extensions.Configuration.Binder
//      System.Data.Common
//      System.Data.Sql
//      System.Data.SqlClient
//      System.Data.SqlTypes
// I am not certain if all these externsions are necessary since
// I am getting my information from two different sources and
// Microsoft's website is somewhat difficult to glean all this
// information from. lol

using System;
using System.IO;
using System.Configuration;
using System.Collections;
using static System.Console;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;


namespace console04
{
    public class ApplicationSettings {
        public string Name {get; set;} = "";
        public string UserID {get; set;} = "";
        public string Password {get; set;} = "";
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
            WriteLine("UserID: {0}", settings.UserID);
            WriteLine("PW: {0}", settings.Password);

            using(SqlConnection connection = new SqlConnection())
            {
                //connection.ConnectionString = cnStrBuilder.ConnectionString;
                connection.ConnectionString = "Data Source=localhost,1401;Initial Catalog=TeachDB;User Id=sa;Password=Passw0rd!";
                connection.Open();
                WriteLine($"Connection Status: {connection.State}");
                string selectStr = "SELECT * FROM dbo.Orders;";
                //string selectStr = "SELECT * FROM dbo.Orders WHERE order_num = 20005;";
                SqlCommand aCmd = new SqlCommand();
                aCmd.Connection = connection;
                aCmd.CommandText = selectStr;
                SqlDataReader dataReader = aCmd.ExecuteReader();
                while (dataReader.Read())
                {
                    WriteLine($"order_num: {dataReader["order_num"]}");
                }
            }

            WriteLine("\n\nProgram Finished!");
        }
    }
}
