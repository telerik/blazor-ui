using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelerikBlazorWASMDashboard.Shared.Models;

namespace TelerikBlazorWASMDashboard.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PodcastDataController : ControllerBase
    {
        private readonly ILogger<PodcastDataController> logger;

        private static List<PodcastViewModel> podcasts = new List<PodcastViewModel>();
        private Random random = new Random();
        private List<string> firstNames = new List<string> { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael", "Robert", "Laura", "Anne", "Nige" };
        private List<string> lastNames = new List<string> { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan", "Suyama", "King", "Callahan", "Dodsworth", "White" };
        private List<string> platforms = new List<string> { "Apple Podcasts", "Spotify", "Other", "Overcast", "Anchor", "Stitcher" };
        private List<string> devices = new List<string> { "iOS", "Android", "Other", "Web" };

        // we generate some data and store it a static variable in this singleton service for simplicity
        // in a real app you should use actaul database and real time data and replace this data retrieval logic
        public PodcastDataController(ILogger<PodcastDataController> logger)
        {
            this.logger = logger;

            if (podcasts.Count == 0)
            {
                podcasts = Enumerable.Range(1, 50).Select(x => new PodcastViewModel()
                {
                    Name = string.Format("Episode #{0} with guest {1} {2}", random.Next(0, 200), firstNames[random.Next(0, firstNames.Count)], lastNames[random.Next(0, lastNames.Count)]),
                    Streams = random.Next(0, 18000),
                    Downloads = random.Next(0, 15000),
                    PlatformName = platforms[random.Next(0, platforms.Count)],
                    Device = devices[random.Next(0, devices.Count)],
                    Date = DateTime.Now.AddDays(-x),
                    Reach = x * random.Next(0, 1000),
                }).ToList();
            }
        }

        [HttpGet]
        [Route("AllPodcasts")]
        public async Task<IEnumerable<PodcastViewModel>> AllPodcasts()
        {
            return await Task.FromResult(podcasts);
        }

        [HttpGet]
        [Route("Streams")]
        public async Task<int> Streams()
        {
            int result = podcasts.Sum(f => f.Streams);
            return await Task.FromResult(result);
        }

        [HttpGet]
        [Route("Downloads")]
        public async Task<int> Downloads()
        {
            int result = podcasts.Sum(f => f.Downloads);
            return await Task.FromResult(result);
        }

        [HttpGet]
        [Route("Reach")]
        public async Task<int> Reach()
        {
            int result = podcasts.Sum(f => f.Reach);
            return await Task.FromResult(result);
        }

        [HttpGet]
        [Route("Revenue")]
        public async Task<double> Revenue()
        {
            double result = podcasts.Sum(f => f.Views) / 100;
            return await Task.FromResult(result);
        }

        [HttpGet]
        [Route("PlatformData")]
        public async Task<IEnumerable<PlatformViewModel>> PlatformData([FromQuery] bool byDevice)
        {
            var deviceViews = podcasts.GroupBy(x => byDevice == true ? x.Device : x.PlatformName)
                                .Select(x => new PlatformViewModel
                                {
                                    Category = x.Key,
                                    Views = x.Sum(v => v.Views)
                                });

            return await Task.FromResult(deviceViews);
        }
    }
}
