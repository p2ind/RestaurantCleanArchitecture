using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteDish;

public class DeleteDishesForRestaurantCommand(Guid restaurantId) : IRequest
{
    public Guid Id { get; set; } = restaurantId;
}
