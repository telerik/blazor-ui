using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using WasmCustomValidation.Shared;

namespace WasmCustomValidation.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyValidationController : ControllerBase
    {
        private readonly ILogger<MyValidationController> logger;

        public MyValidationController(
            ILogger<MyValidationController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MyModel myModel)
        {
            try
            {
                if (myModel.Classification == ClassificationEnum.Defense &&
                    string.IsNullOrEmpty(myModel.Description))
                {
                    ModelState.AddModelError(nameof(myModel.Description),
                        "For a 'Defense' ship " +
                        "classification, 'Description' is required.");
                }
                else
                {
                    logger.LogInformation("Processing the form asynchronously");

                    // Process the valid form
                    // async ...

                    return Ok(ModelState);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Validation Error: {Message}", ex.Message);
            }

            return BadRequest(ModelState);
        }
    }
}
