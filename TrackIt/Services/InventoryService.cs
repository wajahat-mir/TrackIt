using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackIt.Models;
using Microsoft.EntityFrameworkCore;

namespace TrackIt.Services
{
    public interface IInventoryService
    {
        Task<List<InventoryItem>> GetAllInventoryItems();
        Task<InventoryItem> GetInventoryById(long id);
        Task<InventoryItem> GetInventoryByName(string name);
        Task<bool> CreateInventoryItem(InventoryItem inventoryItem);
        Task<bool> UpdateInventoryItem(InventoryItem inventoryitem);
        Task<bool> DeleteInventoryItem(InventoryItem inventoryItem);
    }

    public class InventoryService : IInventoryService
    {
        private readonly InventoryContext _context;

        public InventoryService(InventoryContext context)
        {
            _context = context;
        }

        public async Task<List<InventoryItem>> GetAllInventoryItems()
        {  
            var inventoryItems =  await _context.InventoryItems
                .Include(item => item.Dimension)
                .Include(item => item.Brand)
                    .ThenInclude(brand => brand.CompanyAddress)
                .ToListAsync();
            return inventoryItems;
        }

        public async Task<InventoryItem> GetInventoryById(long id)
        {
            var inventoryItem = await _context.InventoryItems
                .Include(item => item.Dimension)
                .Include(item => item.Brand)
                    .ThenInclude(brand => brand.CompanyAddress)
                .FirstOrDefaultAsync(item => item.Id == id);
            return inventoryItem;
        }

        public async Task<InventoryItem> GetInventoryByName(string name)
        {
            var inventoryItem = await _context.InventoryItems
                .Include(item => item.Dimension)
                .Include(item => item.Brand)
                    .ThenInclude(brand => brand.CompanyAddress)
                .FirstOrDefaultAsync(i => i.ItemName == name);
            return inventoryItem;
        }

        public async Task<bool> CreateInventoryItem(InventoryItem inventoryItem)
        {
            try
            {
                _context.InventoryItems.Add(inventoryItem);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateInventoryItem(InventoryItem inventoryItem)
        {
            try { 
                _context.Entry(inventoryItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteInventoryItem(InventoryItem inventoryItem)
        {
            try
            {
                _context.InventoryItems.Remove(inventoryItem);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
