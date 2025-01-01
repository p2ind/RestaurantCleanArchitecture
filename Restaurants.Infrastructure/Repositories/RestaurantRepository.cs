using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Presistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantRepository(RestaurantsDbContext dbContext) : IRestaurantsRepository
{
    public async Task<Guid> Create(Restaurant restaurant)
    {
       await dbContext.Restaurants.AddAsync(restaurant);
       await dbContext.SaveChangesAsync();
       return restaurant.Id;
    }

    public async Task Delete(Restaurant entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants
            .Include(r=>r.Dishes).ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetByIdAsync(Guid id)
    {
        var restaurants = await dbContext.Restaurants
                                        .Include(r=>r.Dishes)
                                        .FirstOrDefaultAsync(x=>x.Id==id);
        return restaurants;
    }

    public async Task SaveChanges() => await dbContext.SaveChangesAsync();
}
