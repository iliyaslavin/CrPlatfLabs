using System;
using System.IO;
using LabsLibrary;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            PrintHelp();
            return;
        }

        switch (args[0].ToLower())
        {
            case "version":
                PrintVersion();
                break;

            case "run":
                if (args.Length < 2)
                {
                    Console.WriteLine("Please specify a lab to run (lab1, lab2, lab3).");
                    return;
                }
                RunLab(args);
                break;

            case "set-path":
                if (args.Length < 2)
                {
                    Console.WriteLine("Please specify a path using -p or --path.");
                    return;
                }
                SetPath(args[1]);
                break;

            default:
                PrintHelp();
                break;
        }
    }

    static void PrintVersion()
    {
        Console.WriteLine("Author: Slavin Iliya");
        Console.WriteLine("Version: 1.0.0");
    }

    static void RunLab(string[] args)
    {
        string labName = args[1].ToLower();
        string inputFile = GetArgumentValue(args, "-i", "--input") ?? GetDefaultPath("INPUT.txt");
        string outputFile = GetArgumentValue(args, "-o", "--output") ?? GetDefaultPath("OUTPUT.txt");

        if (!File.Exists(inputFile))
        {
            Console.WriteLine($"Input file '{inputFile}' not found.");
            return;
        }

        string inputData = File.ReadAllText(inputFile);
        string result;

        switch (labName)
        {
            case "lab1":
                result = new Lab1().Run(inputData);
                break;
            case "lab2":
                result = new Lab2().Run(inputData);
                break;
            case "lab3":
                result = new Lab3().Run(inputData);
                break;
            default:
                Console.WriteLine("Invalid lab specified.");
                return;
        }

        File.WriteAllText(outputFile, result);
        Console.WriteLine($"Results written to '{outputFile}'");
    }

    static void SetPath(string path)
    {
        Environment.SetEnvironmentVariable("LAB_PATH", path);
        Console.WriteLine($"Path set to '{path}'");
    }

    static string GetArgumentValue(string[] args, string shortArg, string longArg)
    {
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == shortArg || args[i] == longArg)
            {
                return args[i + 1];
            }
        }

        return null;
    }

    static string GetDefaultPath(string fileName)
    {
        string envPath = Environment.GetEnvironmentVariable("LAB_PATH");
        if (!string.IsNullOrEmpty(envPath))
        {
            return Path.Combine(envPath, fileName);
        }

        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), fileName);
    }

    static void PrintHelp()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  version                 Print version info");
        Console.WriteLine("  run [lab1|lab2|lab3] -i <inputFile> -o <outputFile>");
        Console.WriteLine("  set-path -p <path>      Set default path for input/output files");
    }
}
