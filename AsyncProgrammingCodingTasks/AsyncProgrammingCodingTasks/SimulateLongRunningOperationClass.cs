using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgrammingCodingTasks
{
    //    Task 1: Basic Asynchronous Method
    //Objective: Implement an asynchronous method that simulates a time-consuming operation.

    //Instructions:

    //Create a method SimulateLongRunningOperationAsync that takes an integer delayInSeconds.
    //Inside the method, use Task.Delay to simulate a long-running operation.
    //Print a message before and after the delay to indicate the start and end of the operation.
    //Call this method from your Main method and ensure the program waits for its completion.
    public static class SimulateLongRunningOperationClass
    {
        public static async Task SimulateLongRunningOperationAsync(int delayInSec)
        {
            Console.WriteLine("Long-running operation has started.");
            await Task.Delay(delayInSec * 1000);
            Console.WriteLine("Long-running operation has completed");
        }

    }
}
