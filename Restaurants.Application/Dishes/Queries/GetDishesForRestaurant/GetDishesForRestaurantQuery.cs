using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishesForRestaurants;

public class GetDishesForRestaurantQuery(Guid restaurantId) :IRequest<IEnumerable<DishDto>>
{
    public Guid RestaurantId { get; set; } = restaurantId;
}
