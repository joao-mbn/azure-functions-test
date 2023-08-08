using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
  public class QueueTrigger1
  {
    [FunctionName("QueueTrigger1")]
    public static void Run(
      [QueueTrigger("thequeue", Connection = "AzureWebJobsStorage")] string myQueueItem,
      [Blob("mock-images/Screenshot 2023-03-16 155751.png", FileAccess.Read, Connection = "AzureWebJobsStorage")] Stream myPic,
      ILogger log)
    {
      log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
      log.LogInformation(myPic.Length.ToString() + "bytes");
    }

    [FunctionName("DynamicInputQueueTrigger")]
    public static void AnotherRun(
      [QueueTrigger("thequeue", Connection = "AzureWebJobsStorage")] string myQueueItem,
      [Blob("mock-images/{queueTrigger}.png", FileAccess.Read, Connection = "AzureWebJobsStorage")] Stream myPic,
      ILogger log)
    {
      log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
      log.LogInformation(myPic.Length.ToString() + "bytes");
    }
  }
}
