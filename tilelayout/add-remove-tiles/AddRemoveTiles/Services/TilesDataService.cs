using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddRemoveTiles.Models;

namespace AddRemoveTiles.Services
{
    public class TilesDataService
    {
        public Task<List<TileItem>> GetTilesDataAsync()
        {
            return Task.FromResult( new List<TileItem>
        {
            new TileItem()
            {
                Title = "Total Streams",
                Content = "TotalStreams",
                RowSpan = 1,
                Colspan = 1
            },
            new TileItem()
            {
                Title = "Total Downloads",
                Content = "TotalDownloads",
                RowSpan = 1,
                Colspan = 1
            },
            new TileItem()
            {
                Title = "Total Reach",
                Content = "TotalReach",
                RowSpan = 1,
                Colspan = 1
            },
            new TileItem()
            {
                Title = "Total Revenue",
                Content = "TotalRevenue",
                RowSpan = 1,
                Colspan = 1
            },
            new TileItem()
            {
                Title = "Weekly Recap-Downloads",
                Content = "WeeklyRecap",
                RowSpan = 2,
                Colspan = 2
            },
            new TileItem()
            {
                Title = "Performance Trend",
                Content = "PerformanceTrend",
                RowSpan = 2,
                Colspan = 2
            },
            new TileItem()
            {
                Title = "Top 5 Episodes",
                Content = "TopEpisodes",
                RowSpan = 2,
                Colspan = 4
            }
    });
        }

    }
}
