using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Demo
{
    public class MyController : Controller
    {
        private readonly IOptionsMonitor<MyOptions> optionsMonitor;
        private readonly ILogger<MyController> logger;

        public MyController(
            IOptionsMonitor<MyOptions> optionsMonitor,
            ILogger<MyController> logger)
        {
            this.optionsMonitor = optionsMonitor;
            this.logger = logger;
        }

        [Route("ping")]
        public IActionResult Ping()
        {
            this.logger.LogInformation($"MyValue = {this.optionsMonitor.CurrentValue.MyValue}");

            return new OkResult();
        }
    }
}
