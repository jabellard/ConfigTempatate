using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConfigTemplate.ContentRoot.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConfigTemplate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TestSettings _testSettings;
        private readonly ISettings _staticSettings;
        private readonly ILogger _logger;
        public ValuesController(IOptionsSnapshot<TestSettings> testSettings, ISettings staticSetttings, ILogger<ValuesController> logger)
        {
            _testSettings = testSettings.Value;
            _staticSettings = staticSetttings;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            for (int i = 0; i < 10; i++)
            {
                _logger.LogCritical("{InterationValue}: Before returning values", i);
            }
            return new string[] {"value1", "value2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return _staticSettings.Key;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}