using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
  public class TimerTriggerWithQueueOutput
  {
    [FunctionName("TimerTriggerWithQueueOutput")]
    [return: Queue("thequeue", Connection = "AzureWebJobsStorage")]
    public static string Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer, ILogger log)
    {
      log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
      return "Vrau";
      //return $"Vraaaaaaaaaaaau at {DateTime.Now}";
    }
  }
}
