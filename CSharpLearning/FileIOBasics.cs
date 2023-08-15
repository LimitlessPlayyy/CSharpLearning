using System;
using System.IO;

namespace CSharpLearning
{

    partial class Program
    {
        static void ReadTextFromFile()
        {
            // file path needs to be fixed
            string filePath = "/Users/dangercritter/Projects/CSharpLearning/CSharpLearning/SampleText.txt";

            // File class (here to see if the file exists)
            if (File.Exists(filePath))
            {
                // Use StreamReader class to
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    // read a single line at a time from the file
                    string? line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }

                }
            }
            else
                Console.WriteLine("file " + filePath + " doesn't exist");
        }

    }



}

