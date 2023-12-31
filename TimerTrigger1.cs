using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
  public class TimerTrigger1
  {
    [FunctionName("TimerTrigger1")]
    public void Run([TimerTrigger("0 */15 * * * *")] TimerInfo myTimer, ILogger log)
    {
      log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
    }
  }
}
