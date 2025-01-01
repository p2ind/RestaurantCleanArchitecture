using MediatR;
using Restaurants.Application.Dishes.Dtos;

namespace Restaurants.Application.Dishes.Queries.GetDishByIdForRestaurant;

public class GetDishByIdForRestaurantQuery(Guid restaurantId, int dishId) : IRequest<DishDto>
{
    public Guid RestaurantId { get; set; } = restaurantId;
    public int DishId { get; set;} = dishId;
}
