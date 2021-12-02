using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using RestaurantAPI.Entities;
using RestaurantAPI.Exceptions;

namespace RestaurantAPI.Authorization
{
    public class MinimumRestaurantsRequirementHandler : AuthorizationHandler<MinimumRestaurantsRequirement>
    {
        private readonly RestaurantDbContext _context;

        public MinimumRestaurantsRequirementHandler(RestaurantDbContext context)
        {
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumRestaurantsRequirement requirement)
        {
            var userId = int.Parse(context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value);

            var createdRestaurantsCount = _context
                .Restaurants
                .Count(r => r.CreatedById == userId);

            if(createdRestaurantsCount >= requirement.AmountOfRestaurants)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
