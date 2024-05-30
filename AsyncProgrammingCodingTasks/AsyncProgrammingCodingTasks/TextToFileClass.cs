using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AsyncProgrammingCodingTasks
{
    public static class TextToFileClass
    {
        //        Task: Asynchronous File I/O
        //Objective: Implement asynchronous file read and write operations.
        //Instructions:
        //Create a method WriteTextToFileAsync that takes a file path and a string content.
        //Use StreamWriter to write the content to the specified file asynchronously.
        //        Create a method ReadTextFromFileAsync that takes a file path.
        //Use StreamReader to read the content of the specified file asynchronously and return it as a string.
        //In your Main method, write some text to a file and then read it back, printing the content to the console.
        public static async Task WriteToFileAsync(string pathToFile, string text)
        {

            using var sourceStrm = new StreamWriter(File.Create(pathToFile));

            await sourceStrm.WriteAsync(text);
            
            // Simple implementation without StreamWriter

            //await File.WriteAllTextAsync(pathToFile, text);
        }

        public static async Task<string> ReadTextFromFileAsync(string pathToFile)
        {
            using var stream = new StreamReader(pathToFile);

            string result = await stream.ReadToEndAsync();
            Console.WriteLine(result);
            return result;

            //Simple implementation

            //await File.ReadAllTextAsync(pathToFile);
        }
    }
}
