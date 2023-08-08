using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
  public class BlobTrigger1
  {
    [FunctionName("BlobTrigger1")]
    [return: Table("uploadtable", Connection = "AzureWebJobsStorage")]
    public static Upload Run(
      [BlobTrigger("mock-images/{name}", Connection = "AzureWebJobsStorage")] Stream myBlob,
      string name,
      ILogger log)
    {
      log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
      return new Upload()
      {
        PartitionKey = "Uploads",
        RowKey = Guid.NewGuid().ToString(),
        Name = name,
        Length = myBlob.Length
      };
    }
  }

  public class Upload
  {
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public string Name { get; set; }
    public long Length { get; set; }
  }
}
