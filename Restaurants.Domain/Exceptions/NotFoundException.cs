namespace Restaurants.Domain.Exceptions;

public class NotFoundException(string resoureType, string resourceIdentifier) : Exception($"{resoureType} with id: {resourceIdentifier} doesn't exist")
{
}
