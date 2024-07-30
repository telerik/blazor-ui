using Microsoft.AspNetCore.Mvc;
using RemoteValidationWasm.Shared;

namespace RemoteValidationWasm.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    // This static list acts as our database in this app.
    private static List<WeatherForecast> _forecasts { get; set; } = new();
    private int _lastId { get; set; }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        if (!_forecasts.Any())
        {
            _forecasts = Enumerable.Range(1, 15).Select(index => new WeatherForecast
            {
                Id = ++_lastId,
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }

        return _forecasts;
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int idToRemove)
    {
        if (_forecasts == null)
        {
            throw new NullReferenceException("No data.");
        }

        // Dummy validation
        if (idToRemove <= 5)
        {
            return BadRequest("Cannot delete the first five items.");
        }

        WeatherForecast forecastToDelete = _forecasts.Where(f => f.Id == idToRemove).First();
        if (forecastToDelete != null)
        {
            _forecasts.Remove(forecastToDelete);
        }

        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Update(WeatherForecast forecastToUpdate)
    {
        if (ModelState.IsValid)
        {
            if (_forecasts == null)
            {
                throw new NullReferenceException("No data.");
            }

            // Dummy validation
            bool isThereAnIssue = !(forecastToUpdate.Summary ?? string.Empty).ToLowerInvariant().Contains("q");
            if (isThereAnIssue)
            {
                return BadRequest("The Summary must contain the letter 'Q'.");
            }

            var index = _forecasts.FindIndex(i => i.Id == forecastToUpdate.Id);
            if (index != -1)
            {
                _forecasts[index] = forecastToUpdate;
            }

            return Ok(forecastToUpdate);
        }
        else
        {
            //TODO: Handle this server validation failure case if needed.
            return BadRequest(ModelState);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Put(WeatherForecast forecastToInsert)
    {
        if (ModelState.IsValid)
        {
            if (_forecasts == null)
            {
                throw new NullReferenceException("No data.");
            }

            // Dummy validation
            bool isMatchingDate = _forecasts.Where(f => f.Date.Date.Equals(forecastToInsert.Date.Date)).Any();
            if (isMatchingDate)
            {
                return BadRequest($"Date {forecastToInsert.Date.Date} already exists.");
            }

            WeatherForecast insertedForecast = new WeatherForecast()
            {
                Id = _forecasts.Count + 1,
                Date = forecastToInsert.Date,
                TemperatureC = forecastToInsert.TemperatureC,
                Summary = forecastToInsert.Summary
            };

            _forecasts.Insert(0, insertedForecast);

            return Ok(insertedForecast);
        }
        else
        {
            //TODO: Handle this server validation failure case if needed.
            return BadRequest(ModelState);
        }
    }
}
