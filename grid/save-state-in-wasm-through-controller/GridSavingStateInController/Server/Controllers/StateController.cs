using Microsoft.AspNetCore.Mvc;
using Telerik.Blazor.Components;
using GridSavingStateInController.Shared;

namespace GridSavingStateInController.Server.Controllers
{
    [ApiController]
    public class StateController : ControllerBase
    {
        //We save the state for the demo in property. In real case, the state should be saved in a Database.
        public static GridState<SampleData> GridCurrentState { get; set; }

        [HttpPost]
        [Route("setstate")]
        public IActionResult SetState(GridState<SampleData> state)
        {
            var currentState = state;

            GridCurrentState = currentState;

            return Ok();
        }
        
        [HttpGet]
        [Route("getstate")]
        public GridState<SampleData> GetState()
        {
            return GridCurrentState;
        }
    }
}
