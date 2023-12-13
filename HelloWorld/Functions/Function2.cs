using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace HelloWorld.Functions
{
    public class Function2
    {
        private readonly ILogger _logger;

        public Function2(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function2>();
        }

        [Function("Function2")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function 2 processed a request.");

            var res = req.CreateResponse(HttpStatusCode.OK);
            res.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            var query = req.Url.Query;
            var name = req.Query["name"];

            if (!string.IsNullOrEmpty(name))
            {
                res.WriteString($"Hello {name}");
            }
            else
            {
                res.WriteString("Not provided your name");
            }

            return res;
        }
    }
}
