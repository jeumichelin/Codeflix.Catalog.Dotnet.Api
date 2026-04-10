using Codeflix.Catalog.Dotnet.Application.Interfaces;
using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Common;
using Codeflix.Catalog.Dotnet.Domain.Repository.Interfaces;
using DomainEntity = Codeflix.Catalog.Dotnet.Domain.Entities;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.Create;

public class CreateCategoryRequestHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
{
    public async Task<CategoryModelResponse> Handle(CreateCategoryRequest input, CancellationToken cancellationToken)
    {
        var category = new DomainEntity.Category(
            input.Name,
            input.Description,
            input.IsActive
        );

        await categoryRepository.Insert(category, cancellationToken);
        await unitOfWork.Commit(cancellationToken);
        
        return CategoryModelResponse.FromCategory(category);
    }
}
