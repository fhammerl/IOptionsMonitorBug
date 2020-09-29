using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Demo
{
    public class MyController : Controller
    {
        private readonly IOptionsMonitor<MyOptions> optionsMonitor;

        public MyController(IOptionsMonitor<MyOptions> optionsMonitor) => this.optionsMonitor = optionsMonitor;

        [Route("ping")]
        public IActionResult Ping()
        {
            Console.WriteLine(this.optionsMonitor.CurrentValue.MyValue);

            return new OkResult();
        }
    }
}
