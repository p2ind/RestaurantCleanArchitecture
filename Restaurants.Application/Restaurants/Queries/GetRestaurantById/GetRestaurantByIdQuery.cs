using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

public class GetRestaurantByIdQuery(Guid id) : IRequest<RestaurantDto>
{
    public Guid Id { get; set; } = id;
}
