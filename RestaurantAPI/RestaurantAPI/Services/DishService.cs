using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Exceptions;
using AutoMapper;

namespace RestaurantAPI.Services
{
    public interface IDishService
    {
        int Create(int restaurantId, CreateDishDto dto);
        DishDto GetById(int restaurantId, int dishId);

        List<DishDto> GetAll(int restaurantId);

        void RemoveOne(int restaurantId, int dishId);

        void RemoveAll(int restaurantId);
    }

    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        public DishService(RestaurantDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(int restaurantId, CreateDishDto dto)
        {
            var restaurant = GetRestaurantsById(restaurantId);


            var dishEntity = _mapper.Map<Dish>(dto);

            dishEntity.RestaurantId = restaurantId;
            //dishEntity.Restaurant = _dbContext.Restaurants.FirstOrDefault(r => r.Id == restaurantId);

            _dbContext.Dishes.Add(dishEntity);
            _dbContext.SaveChanges();

            return dishEntity.Id;
        }

        public DishDto GetById(int restaurantId, int dishId)
        {
            var restaurant = GetRestaurantsById(restaurantId);


            var dish = _dbContext.Dishes.FirstOrDefault(d => d.Id == dishId);

            if (dish is null || dish.RestaurantId != restaurantId)
            {
                throw new NotFoundException("Dish not found.");
            }

            var result = _mapper.Map<DishDto>(dish);

            return result;
        }

        public List<DishDto> GetAll(int restaurantId)
        {
            var restaurant = GetRestaurantsById(restaurantId);

            var dishDtos = _mapper.Map<List<DishDto>>(restaurant.Dishes);

            return dishDtos;
        }

        public void RemoveOne(int restaurantId, int dishId)
        {
            var restaurant = GetRestaurantsById(restaurantId);

            var dish = _dbContext.Dishes.FirstOrDefault(d => d.Id == dishId);

            if (dish is null || dish.RestaurantId != restaurantId)
            {
                throw new NotFoundException("Dish not found.");
            }

            _dbContext.Dishes.Remove(dish);
            _dbContext.SaveChanges();
        }

        public void RemoveAll(int restaurantId)
        {
            var restaurant = GetRestaurantsById(restaurantId);

            _dbContext.RemoveRange(restaurant.Dishes);
            _dbContext.SaveChanges();
        }

        private Restaurant GetRestaurantsById(int restaurantId)
        {
            var restaurant = _dbContext
                .Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefault(r => r.Id == restaurantId);

            if (restaurant is null)
                throw new NotFoundException("Restaurant not found.");

            return restaurant;
        }
    }
}
