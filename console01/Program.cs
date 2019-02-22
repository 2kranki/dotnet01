// A simple console application to investigate some .Net Core


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace console01
{
    class Program
    {
        static int Main(string[] args)
        {
            // Do initialization.
            WriteLine("Program.Main:");
            WriteLine();

            // Dump command line args.
            Console.WriteLine("cArgs: {0}", args.Length);
            for (int i = 0; i < args.Length; i++)
                Console.WriteLine("Arg: {0} {1}", i, args[i]);

            // Dump System.Environment Stuff.
            string[] envArgs = Environment.GetCommandLineArgs();
            WriteLine("cEnvArgs: {0}", envArgs.Length);
            foreach (string arg in envArgs)
                WriteLine("envArg: {0}", arg);
           foreach (string drive in Environment.GetLogicalDrives())
                WriteLine("Drive: {0}", drive);
            WriteLine("OS: {0}", Environment.OSVersion);
            WriteLine("Number of processors: {0}", Environment.ProcessorCount);
            WriteLine(".NET Version: {0}", Environment.Version);
            WriteLine("Current Directory: {0}", Environment.CurrentDirectory);
            WriteLine("System Directory: {0}", Environment.SystemDirectory);
            WriteLine("User Name: {0}", Environment.UserName);
            IDictionary envVars = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry envVarPair in envVars)
                WriteLine("\tenvVar: {0} - {1}", envVarPair.Key, envVarPair.Value);
            
            // Wait for Enter key.
            Console.ReadLine();

            // Return to O/S.
            return 0;
        }

    }
}

