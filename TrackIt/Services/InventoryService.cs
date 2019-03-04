using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackIt.Models;

namespace TrackIt.Services
{
    public class InventoryService
    {
        private InventoryContext _context;

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
            return _context.InventoryItems
                .Where(item => item.Id == id).FirstOrDefault<InventoryItem>();
        }
    }

    
}
