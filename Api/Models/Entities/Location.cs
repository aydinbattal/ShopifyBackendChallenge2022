using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Entities
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }
        public List<Inventory> Inventories { get; set; }
    }
}