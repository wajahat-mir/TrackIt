using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackIt.Entities;
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
                    Id = 1234567890,
                    Name = "Toaster",
                    Cost = 6.93,
                    Quantity = 1,
                    dimensions = new Dimension
                    {
                        length = 10,
                        width = 10,
                        depth = 5,
                        units = "inches"
                    },
                    brand = new Brand
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
            return await _context.InventoryItems.ToListAsync();
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryItem>> GetInventoryItem(long id)
        {
            var inventoryItem = await _context.InventoryItems.FindAsync(id);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return inventoryItem;
        }

        // GET: api/Inventory/Toaster
        [HttpGet("{Name}")]
        public async Task<ActionResult<InventoryItem>> GetInventoryItemByNameAsync(string name)
        {
            var inventoryItem = await _context.InventoryItems.SingleAsync(i => i.Name == name);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return inventoryItem;
        }

        // POST: api/Inventory
        [HttpPost]
        public async Task<ActionResult<InventoryItem>> PostInventoryItem(InventoryItem inventoryItem)
        {
            _context.InventoryItems.Add(inventoryItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("InventoryItem", new { id = inventoryItem.Id }, inventoryItem);
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
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
            var inventoryItem = await _context.InventoryItems.FindAsync(id);
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
