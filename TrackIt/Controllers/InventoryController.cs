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
        }

        [HttpGet]
        public async Task<IActionResult> GetInventoryItems()
        {
            var inventoryItems = await _context.InventoryItems
                .Include(item => item.Dimension)
                .Include(item => item.Brand)
                    .ThenInclude(brand => brand.CompanyAddress)
                .ToListAsync();
            return Ok(inventoryItems);
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryItem(long id)
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

            return Ok(inventoryItem);
        }

        // GET: api/Inventory/Toaster
        [HttpGet("ByName/{Name}")]
        public async Task<IActionResult> GetInventoryItemByNameAsync(string name)
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

            return Ok(inventoryItem);
        }

        // POST: api/Inventory
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> PostInventoryItem(InventoryItem inventoryItem)
        {
            if (ModelState.IsValid)
            {
                _context.InventoryItems.Add(inventoryItem);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.Id }, inventoryItem);
            }
            else
                return BadRequest();            
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<IActionResult> PutInventoryItem(long id, InventoryItem inventoryItem)
        {

            if (id != inventoryItem.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            _context.Entry(inventoryItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventoryItem(long id)
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

            return Ok(inventoryItem);
        }

    }
}
