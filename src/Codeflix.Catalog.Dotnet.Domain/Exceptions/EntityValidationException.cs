namespace Codeflix.Catalog.Dotnet.Domain.Exceptions;

public class EntityValidationException(string? message) : Exception(message)
{
}
