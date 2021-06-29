using rename_node.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rename_node.Services
{
    /// <summary>
    /// Simulates real data source (database) operations in memory. Replace with actual storage and logic.
    /// </summary>
    public class TreeDataService
    {
        List<TreeItem> items = new List<TreeItem>();

        public async Task<List<TreeItem>> GetData()
        {
            EnsureData();
            return await Task.FromResult(new List<TreeItem>(items));
        }

        public async Task UpdateNode(TreeItem itemToUpdate)
        {
            int itmIndex = items.FindIndex(itm => itm.Id == itemToUpdate.Id);
            if(itmIndex > -1)
            {
                items[itmIndex] = itemToUpdate;
            }
        }

        private void EnsureData()
        {
            if (items == null || !items.Any())
            {
                GenerateData();
            }
        }

        private void GenerateData()
        {
            items = new List<TreeItem>();

            items.Add(new TreeItem()
            {
                Id = 1,
                Text = "Project",
                ParentId = null,
                HasChildren = true,
                Icon = "folder",
                Expanded = true
            });

            items.Add(new TreeItem()
            {
                Id = 2,
                Text = "Design",
                ParentId = 1,
                HasChildren = true,
                Icon = "brush",
                Expanded = true
            });
            items.Add(new TreeItem()
            {
                Id = 3,
                Text = "Implementation",
                ParentId = 1,
                HasChildren = true,
                Icon = "folder",
                Expanded = true
            });

            items.Add(new TreeItem()
            {
                Id = 4,
                Text = "site.psd",
                ParentId = 2,
                HasChildren = false,
                Icon = "psd",
                Expanded = true
            });
            items.Add(new TreeItem()
            {
                Id = 5,
                Text = "index.js",
                ParentId = 3,
                HasChildren = false,
                Icon = "js"
            });
            items.Add(new TreeItem()
            {
                Id = 6,
                Text = "index.html",
                ParentId = 3,
                HasChildren = false,
                Icon = "html"
            });
            items.Add(new TreeItem()
            {
                Id = 7,
                Text = "styles.css",
                ParentId = 3,
                HasChildren = false,
                Icon = "css"
            });
        }
    }
}
