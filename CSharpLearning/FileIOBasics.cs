using System;
using System.IO;

// This demonstrates the basic writing to and reading from a text file

namespace CSharpLearning
{
    partial class Program
    {
        static void WriteToTextFile()
        {
            string filePath = "/Users/dangercritter/Projects/CSharpLearning/CSharpLearning/SampleText.txt";

            if (File.Exists(filePath))
            {
                /* here we are using the override that accepts a 'bool append' paramater
                // which allows us to add or append the file, rather than overriting it
                //   which happens by default, and by specific append: false

                // also notice the "named argument"...
                //   append: true
                //   syntax: MethodName(parameterName: value)
                //  this helps disambiguate paramter usage (especially with multiple overloads)
                //  and make code clearer and more readable. */
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    Console.Write("Write this to text file: ");
                    string? lineToWriteToTextFile = Console.ReadLine();
                    writer.WriteLine(lineToWriteToTextFile) ;
                }
            }
            else
                Console.WriteLine("file " + filePath + " doesn't exist");
        }

        static void ReadTextFromFile()
        {
            // using the absolute path to find our text file
            //   ?^?^? is there any easy way to access this that is in the same directory as our project
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

