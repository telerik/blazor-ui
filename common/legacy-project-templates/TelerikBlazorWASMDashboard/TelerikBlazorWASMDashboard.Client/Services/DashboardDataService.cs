using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TelerikBlazorWASMDashboard.Shared.Models;

namespace TelerikBlazorWASMDashboard.Client.Services
{
    public class DashboardDataService
    {
        [Inject]
        private HttpClient Http { get; set; }

        public DashboardDataService(HttpClient client)
        {
            Http = client;
        }

        // methods from the service that are used across the components to get data
        public async Task<IEnumerable<PodcastViewModel>> GetPodcasts()
        {
            return await Http.GetFromJsonAsync<IEnumerable<PodcastViewModel>>("PodcastData/AllPodcasts") ?? new List<PodcastViewModel>();;
        }

        public async Task<int> GetStreams()
        {
            return await Http.GetFromJsonAsync<int>("PodcastData/Streams");
        }

        public async Task<int> GetDownloads()
        {
            return await Http.GetFromJsonAsync<int>("PodcastData/Downloads");
        }

        public async Task<int> GetReach()
        {
            return await Http.GetFromJsonAsync<int>("PodcastData/Reach");
        }

        public async Task<double> GetRevenue()
        {
            return await Http.GetFromJsonAsync<double>("PodcastData/Revenue");
        }

        public async Task<IEnumerable<PlatformViewModel>> GetPlatformData(bool byDevice)
        {
            return await Http.GetFromJsonAsync<IEnumerable<PlatformViewModel>>("PodcastData/PlatformData?byDevice=" + byDevice) ?? new List<PlatformViewModel>();
        }
    }
}
