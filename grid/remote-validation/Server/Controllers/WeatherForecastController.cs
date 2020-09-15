using RemoteValidationWasm.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace RemoteValidationWasm.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        // this static list acts as our "database" in this sample
        private static List<WeatherForecast> _forecasts { get; set; }

        [HttpGet]
        public Task<List<WeatherForecast>> Get([FromQuery] DateTime startDate)
        {
            if (_forecasts == null)
            {
                var rng = new Random();
                _forecasts = Enumerable.Range(1, 150).Select(index => new WeatherForecast
                {
                    Id = index,
                    Date = startDate.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }).ToList();
            }

            return Task.FromResult(_forecasts);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int idToRemove)
        {
            //implement proper error handling here, and then actual data source operations
            if (_forecasts == null)
            {
                throw new NullReferenceException("no data");
            }

            if(idToRemove < 3)
            {
                return BadRequest("cannot delete the first two items");
            }

            WeatherForecast forecastToDelete = _forecasts.Where(f => f.Id == idToRemove).First();
            if (forecastToDelete != null)
            {
                _forecasts.Remove(forecastToDelete);
            }

            return Ok();
        }



        // The Update and Put (insert) operations perform sample validation and return BadRequest responses
        // instead of the newly updated data. In this example, those responses are simple error messages that we can present
        // to the user and you can update/alter that as necessary.
        // For simplicity, the Update checks for the letter "a" in the summary, the Put checks for duplicate dates.

        [HttpPost]
        public async Task<IActionResult> Update(WeatherForecast forecastToUpdate)
        {
            if (ModelState.IsValid)
            {
                //implement proper error handling here, and then actual data source operations
                if (_forecasts == null)
                {
                    throw new NullReferenceException("data not present");
                }



                // sample server validation - we do not allow the letter "a" in the summary
                bool isThereAnIssue = forecastToUpdate.Summary.ToLowerInvariant().Contains("a");
                if (isThereAnIssue)
                {
                    return BadRequest("The summary cannot contain the letter 'a'");
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
                //todo: implement handling for this server validation failure case if needed
                return BadRequest(ModelState);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Put(WeatherForecast forecastToInsert)
        {
            if (ModelState.IsValid)
            {
                //implement proper error handling here, and then actual data source operations
                if (_forecasts == null)
                {
                    throw new NullReferenceException("data not present");
                }



                // sample server validation - we check whether a forecast for this date already exists and prevent that
                bool isMatchingDate = _forecasts.Where(f => f.Date.Date.Equals(forecastToInsert.Date.Date)).Any();
                if (isMatchingDate)
                {
                    return BadRequest("duplicated date");
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
                //todo: implement handling for this server validation failure case if needed
                return BadRequest(ModelState);
            }
        }
    }
}
