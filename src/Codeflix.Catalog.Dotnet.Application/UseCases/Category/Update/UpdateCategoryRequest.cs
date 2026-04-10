using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Common;
using MediatR;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.Update;

public class UpdateCategoryRequest(
    Guid id, 
    string name, 
    string? description = null, 
    bool? isActive = null) : IRequest<CategoryModelResponse>
{
    public Guid Id { get; set; } = id;

    public string Name { get; set; } = name;

    public string? Description { get; set; } = description;
    
    public bool? IsActive { get; set; } = isActive;
}
