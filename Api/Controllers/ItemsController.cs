using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Entities;
using Api.Models.Persistence;
using Microsoft.AspNetCore.Mvc;

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
            var items = _context.Items;
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

            await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();
            return Ok(newItem);
        }
    }
}