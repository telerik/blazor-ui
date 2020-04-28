using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using export_to_xlsx_hierarchy.Models;
using export_to_xlsx_hierarchy.Helpers;

namespace export_to_xlsx_hierarchy.Pages
{
    public partial class Index
    {
        public IEnumerable<Product> GridData { get; set; }

        readonly DateTime StartDate = new DateTime(2018, 1, 1);
        static readonly Random RandomGenerator = new Random();

        string SelectedFormat { get; set; } = FileFormats.Formats.XLSX.ToString();
        List<string> formats = new List<string>();

        protected override void OnInitialized()
        {
            formats = Enum.GetValues(typeof(FileFormats.Formats))
                .Cast<FileFormats.Formats>()
                .Select(v => v.ToString())
                .ToList();

            GridData = GenerateProducts().AsQueryable();
        }

        private async Task ExportToExcel()
        {
            var selectedFormat = (FileFormats.Formats)Enum.Parse(typeof(FileFormats.Formats), SelectedFormat);

            using var exporter = new ExportHelper(JSRuntime, GridData, format: selectedFormat);
            await exporter.ExportCurrentData();
        }

        private List<Product> GenerateProducts()
        {
            List<Product> products = new List<Product>();

            for (int i = 1; i <= 100; i++)
            {
                var product = new Product()
                {
                    ProductId = i,
                    ProductName = "Product " + i.ToString(),
                    SupplierId = i,
                    UnitPrice = (decimal)(i * 3.14),
                    UnitsInStock = (short)(i * 1),
                    Discontinued = RandomGenerator.NextDouble() >= 0.5,
                    CreatedAt = GetRandomDate(StartDate)
                };

                product.OrderDetails = GenerateOrderDetails(product);

                products.Add(product);
            }

            return products;
        }

        private List<OrderDetails> GenerateOrderDetails(Product product)
        {
            double minDiscount = 0.1;
            double maxDiscount = 0.2;
            var orderDetails = new List<OrderDetails>();

            for (int i = 1; i <= 40; i++)
            {
                orderDetails.Add(new OrderDetails()
                {
                    OrderId = int.Parse($"{product.ProductId}{i}"),
                    UnitPrice = product.UnitPrice,
                    Quantity = (short)(1 + (RandomGenerator.Next() % 10)),
                    Discount = (float)(RandomGenerator.NextDouble() * (maxDiscount - minDiscount) + minDiscount),
                    ProductId = product.ProductId,
                });
            }

            return orderDetails;
        }

        private DateTime GetRandomDate(DateTime startDate)
        {
            int range = (DateTime.Today - startDate).Days;
            return startDate.AddDays(RandomGenerator.Next(range));
        }
    }
}