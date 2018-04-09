
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace demo4developers
{
    public static class Function1
    {
        [FunctionName("ImageResize")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "saveMessage")]HttpRequest req,
            TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string requestBody = new StreamReader(req.Body).ReadToEnd();

            log.Info(requestBody);

            var data = JsonConvert.DeserializeObject<PhotoOrder>(requestBody);

            return data != null
                ? (ActionResult)new OkObjectResult($"Hello, {data.Email}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }

    public class PhotoOrder
    {
        public string Email { get; set; }
        public string FileName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
