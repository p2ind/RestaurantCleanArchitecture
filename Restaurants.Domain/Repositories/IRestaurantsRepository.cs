using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IRestaurantsRepository
{
    Task<IEnumerable<Restaurant>> GetAllAsync();
    Task<IEnumerable<Restaurant>> GetAllMatchingAsync(string? searchPhrase);
    Task<Restaurant?> GetByIdAsync(Guid id);
    Task<Guid> Create(Restaurant restaurant);
    Task Delete(Restaurant entity);
    Task SaveChanges();
}
