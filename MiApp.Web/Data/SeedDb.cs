using MiApp.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiApp.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckItemsAsync();
        }

        private async Task CheckItemsAsync()
        {
            if (!_context.Items.Any())
            {
                AddItem("Item01", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 1.50);
                AddItem("Item02", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 2.50);
                AddItem("Item03", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 3.50);
                AddItem("Item04", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 4.50);
                AddItem("Item05", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 5.50);
                AddItem("Item06", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 6.50);
                AddItem("Item07", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 7.50);
                AddItem("Item08", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 8.50);
                AddItem("Item09", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 9.50);
                AddItem("Item10", $"~/images/Items/1.jpg", true, DateTime.Today, 1, 10.50);
                await _context.SaveChangesAsync();
            }
        }

        private void AddItem(string name, string logoPath,bool active, DateTime date,int quantity,double price)
        {
            _context.Items.Add(new ItemEntity { Name = name, LogoPath = logoPath, Active=active,Date=date,Quantity=quantity,Price=price});
        }
    }
}