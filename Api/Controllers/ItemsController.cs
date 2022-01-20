using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Entities;
using Api.Models.Helpers;
using Api.Models.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] Item newItem)
        {
            var items = _context.Items.Include(x => x.Inventories);
            foreach (var i in items)
            {
                if (i.Name == newItem.Name)
                {
                    var errors = new List<Error>{
                        new Error{
                            Status = BadRequest().StatusCode,
                            Title = "Item already exists",
                            Detail = "This item already exists in the database"
                        }
                    };
                    return BadRequest(errors);
                }

            }

            newItem.ShipmentDate = DateTime.Now;

            var tempInventories = new List<Inventory>();
            foreach (var i in newItem.Inventories)
            {
                var inventoryInDb = _context.Inventories.Include(x => x.Items).SingleOrDefault(x => x.Name.ToLower().Equals(i.Name.ToLower()));
                if (inventoryInDb != null)
                {
                    tempInventories.Add(inventoryInDb);
                }
                else
                {
                    var newInventory = new Inventory
                    {
                        Name = i.Name,
                    };
                    tempInventories.Add(newInventory);
                }
            }

            newItem.Inventories = tempInventories;

            await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();
            return Ok("Item is successfully created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(string id)
        {
            var item = await _context.Items
                .FindAsync(new Guid(id));

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return Ok("Item is successfully removed");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(string id, [FromBody] Item newItem)
        {

            var item = await _context.Items
                .FindAsync(new Guid(id));

            if (newItem.Name != null)
                item.Name = newItem.Name;
            if (newItem.Amount != 0)
                item.Amount = newItem.Amount;

            await _context.SaveChangesAsync();
            return Ok("Item is successfully updated");
        }

        [HttpGet]
        public async Task<IActionResult> GetItems([FromQuery] int pageNumber)
        {
            int pageSize = 10;

            //if nothing provided in query, return page 1
            if (pageNumber == 0)
                pageNumber = 1;

            var totalRecords = await _context.Items.CountAsync();

            var items = _context.Items.Skip((pageNumber - 1) * pageSize).Take(pageSize).OrderBy(x => x.ShipmentDate);

            var response = ResponseHelper<Item>.GetPagedResponse("/api/items?", items, pageNumber, pageSize, totalRecords);

            return Ok(response);
        }
    }
}