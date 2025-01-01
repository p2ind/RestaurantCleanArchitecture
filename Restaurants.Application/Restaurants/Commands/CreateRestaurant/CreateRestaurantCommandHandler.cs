﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Users;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository,
    IUserContext userContext) : IRequestHandler<CreateRestaurantCommand, Guid>
{
    public async Task<Guid> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        var currentUser = userContext.GetCurrentUser();

        logger.LogInformation("{UserName} [{UserId}] is creating a new restaurant {@Restaurant}",
            currentUser.Email,
            currentUser.Id,
            request);

        var restaurant = mapper.Map<Restaurant>(request);
        restaurant.OwnerId = currentUser.Id;

        Guid id = await restaurantsRepository.Create(restaurant);
        return id;
    }
}
