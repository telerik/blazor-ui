using Microsoft.AspNetCore.Mvc;
using Telerik.Blazor.Components;
using GridSavingStateInController.Shared;

namespace GridSavingStateInController.Server.Controllers
{
    [ApiController]
    public class StateController : ControllerBase
    {
        //We save the state in property only for demo purposes. In a real-life scenario, the state could be saved in some persistent storage (Database, cache, etc...)
        private static GridState<SampleData> GridCurrentState { get; set; }

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
