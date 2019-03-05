using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackIt.Models;
using Microsoft.EntityFrameworkCore;

namespace TrackIt.Services
{
    public class InventoryService
    {
        private readonly InventoryContext _context;

        public InventoryService(InventoryContext context)
        {
            _context = context;
        }

        public List<InventoryItem> GetAllInventoryItems()
        {
            return _context.InventoryItems.ToList();
        }

        public InventoryItem GetInventoryById(int id)
        {
            var inventoryitem = _context.InventoryItems
                .Include(item => item.Dimension)
                .Include(item => item.Brand)
                    .ThenInclude(brand => brand.CompanyAddress)
                .FirstOrDefault<InventoryItem>();
            return inventoryitem;
        }

        public Brand GetBrandById(int id)
        {
            var brand = _context.Brands
                .Include(item => item.CompanyAddress)
                .FirstOrDefault<Brand>();
            return brand;
        }
    }

    
}
