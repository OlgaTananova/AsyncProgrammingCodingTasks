using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // Task: Handling Exceptions in Asynchronous Methods
        //Objective: Implement error handling in asynchronous methods.

        //Instructions:

        //Modify the DownloadDataAsync method to handle exceptions such as network errors.
        //If an exception occurs, catch it and return a default message indicating the error.
        //In the FetchMultipleUrlsAsync method, ensure that all tasks complete even if some of them fail.
        //Print a message for each URL indicating whether the download was successful or failed.

        public static async Task<string> DownloadDataWithExceptionHandlingAsync(string url)
        {
            using HttpClient client = new HttpClient();
            Task<string> strFromUrl = client.GetStringAsync(url);
            try
            {

                return await strFromUrl;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error occurred";
            }

        }

        public static async Task FetchMultipleUrlsWithExcepionHandlingAsync(List<string> urls)
        {

            // create a list of tasks
            List<Task<string>> listOfTasks = urls.Select(url => Task.Run(()=> DownloadDataWithExceptionHandlingAsync(url))).ToList();
            
            int successfulTasksCounter = 0;
            int listOfTasksCounter = listOfTasks.Count;

            while (listOfTasks.Any())
            {  
                // await any of tasks to complete
                Task<string> finishedTask = await Task.WhenAny(listOfTasks); 
                    listOfTasks.Remove(finishedTask);
                try
                {
                    string result = await finishedTask;
                    Console.WriteLine($"The task {finishedTask.Id} has finished successfully.");
                    successfulTasksCounter++;
                } catch (Exception ex)
                {
                    Console.WriteLine($"The task {finishedTask.Id} has failed.");
                }
            }

            Console.WriteLine($"{successfulTasksCounter} out of {listOfTasksCounter} have finished successfully.");

        }


    }
}
