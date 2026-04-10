using DomainEntity = Codeflix.Catalog.Dotnet.Domain.Entities;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.Common;

public class CategoryModelResponse(
    Guid id,
    string name,
    string description,
    bool isActive,
    DateTime createdAt
    )
{
    public Guid Id { get; set; } = id;

    public string Name { get; set; } = name;

    public string Description { get; set; } = description;

    public bool IsActive { get; set; } = isActive;

    public DateTime CreatedAt { get; set; } = createdAt;

    public static CategoryModelResponse FromCategory(DomainEntity.Category category)
        => new(
            category.Id,
            category.Name,
            category.Description,
            category.IsActive,
            category.CreatedAt
        );
}
