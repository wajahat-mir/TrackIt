using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackIt.Entities;
using TrackIt.Filters;
using TrackIt.Models;

namespace TrackIt.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly InventoryContext _context;

        public InventoryController(InventoryContext context)
        {
            _context = context;

            if (_context.InventoryItems.Count() == 0)
            {
                _context.InventoryItems.Add(new InventoryItem
                {
                    ItemName = "Toaster",
                    Cost = 6.93,
                    Quantity = 1,
                    Dimension = new Dimension
                    {
                        length = 1,
                        width = 2,
                        depth = 3,
                        units = "cm"
                    },
                    Brand = new Brand
                    {
                        Name = "ToastMaster",
                        ContactPhone = "1234567980",
                        CompanyAddress = new Address
                        {
                            AddressLine1 = "123 Alphabet Street",
                            State = "NY",
                            PostalCode = "12345",
                            City = "New York",
                            Country = "USA"
                        }
                    }
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryItem>>> GetInventoryItems()
        {
            var inventoryItems = await _context.InventoryItems
                .Include(item => item.Dimension)
                .Include(item => item.Brand)
                    .ThenInclude(brand => brand.CompanyAddress)
                .ToListAsync();
            return inventoryItems;
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItem>> GetInventoryItem(long id)
        {
            var inventoryItem = await _context.InventoryItems
                .Include(item => item.Dimension)
                .Include(item => item.Brand)
                    .ThenInclude(brand => brand.CompanyAddress)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return inventoryItem;
        }

        // GET: api/Inventory/Toaster
        [HttpGet("ByName/{Name}")]
        public async Task<ActionResult<InventoryItem>> GetInventoryItemByNameAsync(string name)
        {
            InventoryItem inventoryItem = await _context.InventoryItems
                .Include(item => item.Dimension)
                .Include(item => item.Brand)
                    .ThenInclude(brand => brand.CompanyAddress)
                .FirstOrDefaultAsync(i => i.ItemName == name);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return inventoryItem;
        }

        // POST: api/Inventory
        [HttpPost]
        [ValidateModel]
        public async Task<ActionResult<InventoryItem>> PostInventoryItem(InventoryItem inventoryItem)
        {
            _context.InventoryItems.Add(inventoryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.Id }, inventoryItem);
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> PutInventoryItem(long id, InventoryItem inventoryItem)
        {

            if (id != inventoryItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventoryItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InventoryItem>> DeleteInventoryItem(long id)
        {
            var inventoryItem = await _context.InventoryItems.Include(item => item.Dimension)
                .Include(item => item.Brand)
                    .ThenInclude(brand => brand.CompanyAddress)
                .FirstOrDefaultAsync(item => item.Id == id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            _context.InventoryItems.Remove(inventoryItem);
            await _context.SaveChangesAsync();

            return inventoryItem;
        }

    }
}
