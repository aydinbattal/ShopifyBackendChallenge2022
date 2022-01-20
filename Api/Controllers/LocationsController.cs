using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Entities;
using Api.Models.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : ControllerBase
    {
        private readonly DataContext _context;

        public LocationsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation([FromBody] Location newLocation)
        {
            var locations = _context.Locations.Include(x => x.Inventories);
            foreach (var l in locations)
            {
                if (l.Address == newLocation.Address)
                {
                    var errors = new List<Error>{
                        new Error{
                            Status = BadRequest().StatusCode,
                            Title = "Location already exists",
                            Detail = "This location already exists in the database"
                        }
                    };
                    return BadRequest(errors);
                }

            }

            var tempInventories = new List<Inventory>();
            foreach (var i in newLocation.Inventories)
            {
                var inventoryInDb = _context.Inventories.SingleOrDefault(x => x.Name.ToLower().Equals(i.Name.ToLower()));
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

            newLocation.Inventories = tempInventories;

            await _context.Locations.AddAsync(newLocation);
            await _context.SaveChangesAsync();
            return Ok("Location is successfully created");
        }
    }
}