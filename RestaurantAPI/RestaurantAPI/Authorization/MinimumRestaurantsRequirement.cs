using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Authorization
{
    public class MinimumRestaurantsRequirement : IAuthorizationRequirement
    {
        public int AmountOfRestaurants { get; }

        public MinimumRestaurantsRequirement(int amount)
        {
            AmountOfRestaurants = amount;
        }
    }
}
