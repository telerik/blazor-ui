using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Blazor.Components;
using Telerik.DataSource;
using Telerik.DataSource.Extensions;
using TelerikBlazorServerAdmin.Models;
using TelerikBlazorServerAdmin.Models.Sales;

namespace TelerikBlazorServerAdmin.Pages
{
    public partial class Products
    {
        public Products()
        {

        }

        private List<SalesByDateViewModel> sales = new List<SalesByDateViewModel>();
        private List<ProductDto> products = new List<ProductDto>();
        private List<ProductDto> productsData = new List<ProductDto>();
        int PageSize = 8;
        int CurrentPage = 1;
        public string FilterText { get; set; } = string.Empty;
        TelerikChart BubbleRef { get; set; } = null!;
        public List<int?> PageSizes = new List<int?> { 2, 4, 6, 8, null };

        public class ModelBubbleData
        {
            public double LifeExpectancy { get; set; }
            public double FertilityRate { get; set; }
            public int PopulationChange { get; set; }
            public string Country { get; set; } = string.Empty;
        }

        public List<ModelBubbleData> Series1Data = new List<ModelBubbleData>()
        {
            new ModelBubbleData() { LifeExpectancy = 80.66, FertilityRate = 1.27, PopulationChange = 500000, Country = "Canada" },
            new ModelBubbleData() { LifeExpectancy = 78.09, FertilityRate = 2.3, PopulationChange = 7600000, Country = "USA" }
        };

        public List<ModelBubbleData> Series2Data = new List<ModelBubbleData>()
        {
            new ModelBubbleData() { LifeExpectancy = 67.3, FertilityRate = 1.54, PopulationChange = 25000, Country = "Denmark" },
            new ModelBubbleData() { LifeExpectancy = 74.3, FertilityRate = 1.85, PopulationChange = 3000000, Country = "Great Britain" }
        };

        private void Filter()
        {
            var request = new DataSourceRequest()
            {
                Filters = new List<IFilterDescriptor>()
            };
            request.Filters.Add(new FilterDescriptor("Title", FilterOperator.Contains, FilterText));

            productsData = products.ToDataSourceResult(request).Data.Cast<ProductDto>().ToList();
        }

        void OnItemResize()
        {
            BubbleRef.Refresh();
        }

        protected override void OnInitialized()
        {
            sales = _dataService.GetSales().Where(sale => sale.TransactionDate > new DateTime(2019, 12, 30) && sale.TransactionDate < new DateTime(2019, 12, 31))
                .Select(s => new SalesByDateViewModel
                {
                    Sum = s.Amount,
                    SumOne = s.Amount + 100,
                    SumTwo = s.Amount + 200,
                    SumThree = s.Amount + 300,
                    X = s.Id + 500,
                    Y = (int)s.Amount + 250,
                    Size = (int)s.Amount + 600,
                })
                .ToList();

            var Titles = new string[] {
                "All-in-One Mac",
                "Colorful Future with SSG500",
                "The Prestige Series",
                "Designs into Websites",
                "Out of the Shadow",
                "Design Solutions",
                "Remote Life",
                "Through the Lens",
                "Wireless Culture",
                "Changing the Game",
                "Thin Tech",
                "Mobile Edu"
            };
            var Descriptions = new string[]
            {
                "An alternative solution for your business. Get our latest offer now and save up to $300 with the terrific All-in-One Mac laptop!",
                "Add some color to the dull and grey everyday life with our latest  laptop offer! SSG500 will bring your creative ideas to life!",
                "The SA325 Prestige Series deliver an excellent audio performance, combined with the best noise cancellation and a ton of additional features.",
                "Advance the web development process with Artificial Design Intelligence to deliver the best user experience directly through your website.",
                "This is the right place if you’re trying to reduce your Shadow IT risk. Explore our latest guide on how to protect and manage your software assets.",
                "This is the right place if you’re looking for a new laptop design. Spice up your environment with our fresh ideas for laptop skins, stickers, and sleeves.",
                "Smart phones of the future are coming our way! Get a glimpse of how they might develop and what to expect from their functionalities.",
                "Look forward to the future in a different light with AI. Enjoy better, faster, and more intuitive photos in the 3D world.",
                "Listen to your favorite genres with style! Our latest headphone design offers excellent wireless audio for a better music experience.",
                "The future of the headphone technology is wireless. Get to know the latest trends for fashionable designs and improvements in the headphone world.",
                "The changing technology and economy are driving a new world of mobile computing. Explore our super-thin designs with folding displays.",
                "Harness the nature of the mobile phone with our latest Mobile Edu design, created to assist you with your studies for a more informal approach to learning.",
            };
            products = Enumerable.Range(1, 50).Select(x => new ProductDto
            {
                ID = x,
                Title = Titles[x % 12],
                Description = Descriptions[x % 12]
            }).ToList();

            Filter();
        }
    }
}
