namespace AsyncProgrammingCodingTasks
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await SimulateLongRunningOperationClass.SimulateLongRunningOperationAsync(3);

            //Console.WriteLine(await DownloadDataClass.DownloadDataAsync("https://learn.microsoft.com/dotnet"));

            await DownloadDataClass.FetchMultipleUrlsAsync(new List<string>
            {
                "https://learn.microsoft.com",
                "https://learn.microsoft.com/aspnet/core",
                "https://learn.microsoft.com/azure",
                "https://learn.microsoft.com/azure/devops",
                "https://learn.microsoft.com/dotnet",
            });
        }
    }
}
