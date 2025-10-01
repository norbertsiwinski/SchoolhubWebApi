namespace Schoolhub.Application.Common;

public class NotFoundException(string resourceType, string? resourceIdentifier)
: Exception($"{resourceType} with id: {resourceIdentifier} does not exists!")
{
}