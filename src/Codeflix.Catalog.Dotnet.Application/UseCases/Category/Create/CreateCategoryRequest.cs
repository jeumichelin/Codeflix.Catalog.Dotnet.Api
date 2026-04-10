using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Common;
using MediatR;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.Create;

public class CreateCategoryRequest(
    string name,
    string? description = null,
    bool isActive = true) : IRequest<CategoryModelResponse>
{
    public string Name { get; set; } = name;

    public string Description { get; set; } = description ?? "";

    public bool IsActive { get; set; } = isActive;
}
