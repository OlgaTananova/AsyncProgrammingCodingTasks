namespace AsyncProgrammingCodingTasks
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region Basic Examples
            //await SimulateLongRunningOperationClass.SimulateLongRunningOperationAsync(3);

            //Console.WriteLine(await DownloadDataClass.DownloadDataAsync("https://learn.microsoft.com/dotnet"));

            //await DownloadDataClass.FetchMultipleUrlsAsync(new List<string>
            //{
            //    "https://learn.microsoft.com",
            //    "https://learn.microsoft.com/aspnet/core",
            //    "https://learn.microsoft.com/azure",
            //    "https://learn.microsoft.com/azure/devops",
            //    "https://learn.microsoft.com/dotnet",
            //});

            //await DownloadDataClass.FetchMultipleUrlsWithExcepionHandlingAsync(new List<string>
            //{
            //    "https://learn.microsoft.com",
            //    "https://.microsoft.com/aspnet/c", // this url is not valid
            //    "https://learn.microsoft.com/azure",
            //    "https://learn.microsoft.com/azure/devops",
            //    "https://learn.microsoft.com/dotnet",
            //});
            #endregion

            #region File I/O
            await TextToFileClass.WriteToFileAsync("example.txt", "Hello World!");
            await TextToFileClass.ReadTextFromFileAsync("example.txt");
            #endregion
        }
    }
}
