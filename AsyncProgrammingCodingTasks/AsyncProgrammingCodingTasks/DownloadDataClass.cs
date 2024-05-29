using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AsyncProgrammingCodingTasks
{
    public static class DownloadDataClass
    {
        // Task : Downloading Data Asynchronously
        //Objective: Implement an asynchronous method to download data from a web API.

        //Instructions:

        //Create a method DownloadDataAsync that takes a URL as a string parameter.
        //Use HttpClient to send an asynchronous GET request to the specified URL.
        //Read the response content asynchronously.
        //Return the content as a string.
        //Call this method from your Main method and display the downloaded data.
        public static async Task<string> DownloadDataAsync(string url)
        {
            using HttpClient client = new HttpClient();
            Task<string> strFromUrl = client.GetStringAsync(url);
            Console.WriteLine("The request to the url has started.");
            string result = await strFromUrl;
            return result;
        }


        //Task: Parallel Asynchronous Operations
        //Objective: Execute multiple asynchronous operations in parallel and wait for all of them to complete.

        //Instructions:

        //Create a method FetchMultipleUrlsAsync that takes a list of URLs.
        //For each URL, call the DownloadDataAsync method from Task 2.
        //Use Task.WhenAll to wait for all download tasks to complete.
        //Print the length of the content downloaded from each URL.
        //Call this method from your Main method with a list of URLs.
        public static async Task FetchMultipleUrlsAsync(List<string> urls)
        {

            try
            {
                List<Task<string>> listOfTasks = new List<Task<string>>();
                foreach (string url in urls)
                {
                    listOfTasks.Add(Task.Run(() => DownloadDataAsync(url)));
                }

                string[] result = await Task.WhenAll(listOfTasks);
                foreach (string str in result)
                {
                    Console.Write(str.Length + " ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
