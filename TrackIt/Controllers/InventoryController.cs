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
using TrackIt.Services;

namespace TrackIt.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : Controller
    {
        private readonly IInventoryService _service;

        public InventoryController(IInventoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetInventoryItems()
        {
            return Ok(_service.GetAllInventoryItems().Result);
        }

        // GET: api/Inventory/5
        [HttpGet("{id}")]
        public IActionResult GetInventoryItem(long id)
        {
            var inventoryItem = _service.GetInventoryById(id).Result;

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return Ok(inventoryItem);
        }

        // GET: api/Inventory/Toaster
        [HttpGet("ByName/{Name}")]
        public IActionResult GetInventoryItemByName(string name)
        {
            var inventoryItem = _service.GetInventoryByName(name).Result;

            if (inventoryItem == null)
            {
                return NotFound();
            }

            return Ok(inventoryItem);
        }

        // POST: api/Inventory
        [HttpPost]
        [ValidateModel]
        public IActionResult PostInventoryItem(InventoryItem inventoryItem)
        {
            var returnValue = _service.CreateInventoryItem(inventoryItem).Result;

            if (!returnValue)
                return BadRequest();

            return CreatedAtAction("GetInventoryItem", new { id = inventoryItem.Id }, inventoryItem);       
        }

        // PUT: api/Inventory/5
        [HttpPut("{id}")]
        [ValidateModel]
        public IActionResult PutInventoryItem(long id, InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
                return BadRequest();

            var returnValue = _service.UpdateInventoryItem(inventoryItem).Result;

            if (!returnValue)
                return BadRequest();

            return NoContent();
        }

        // DELETE: api/Inventory/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInventoryItem(long id)
        {
            var inventoryItem = _service.GetInventoryById(id).Result;

            if (inventoryItem == null)
            {
                return NotFound();
            }

            var returnValue = _service.DeleteInventoryItem(inventoryItem).Result;

            if (!returnValue)
                return BadRequest();

            return Ok(inventoryItem);
        }

    }
}
