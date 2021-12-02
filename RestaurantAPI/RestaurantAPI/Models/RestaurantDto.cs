using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Models
{
    public class RestaurantDto
    {
        public int ID { get; set; }

        public string Name { get; set; }    // do filtracji dobre
        public string Description { get; set; } // do filtracji dobre
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }

        public List<DishDto> Dishes { get; set; }
    }
}
