using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RemoteValidationInGridEditorTemplate.Shared;

namespace RemoteValidationInGridEditorTemplate.Server.Controllers
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
        public async Task<IActionResult> Post(SampleData myModel)
        {
            try
            {
                if (myModel.Name == "Nameee")
                {
                    ModelState.AddModelError(nameof(myModel.Name),
                        "Name field cannot be 'Namee'.");
                }
                else if (string.IsNullOrEmpty(myModel.Name))
                {
                    ModelState.AddModelError(nameof(myModel.Name),
                        "Name field is required.");
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
