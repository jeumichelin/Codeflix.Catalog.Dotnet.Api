using Codeflix.Catalog.Dotnet.Application.Exceptions;
using Codeflix.Catalog.Dotnet.Application.Interfaces;
using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Common;
using Codeflix.Catalog.Dotnet.Domain.Repository.Interfaces;
using MediatR;
using DomainEntity = Codeflix.Catalog.Dotnet.Domain.Entities;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.Update;

public class UpdateCategoryRequestHandler(ICategoryRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryRequest, CategoryModelResponse>
{
    public async Task<CategoryModelResponse> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await repository.Get(request.Id, cancellationToken) ?? 
            throw new NotFoundException($"Category '{request.Id}' not found");

        category.Update(request.Name, request.Description);
        ManageActivation(category, request.IsActive);
        await repository.Update(category, cancellationToken);

        await unitOfWork.Commit(cancellationToken);

        return CategoryModelResponse.FromCategory(category);
    }

    private static void ManageActivation(DomainEntity.Category category, bool? isActive)
    {
        if (!isActive.HasValue)
            return;

        if (isActive.Value)
            category.Activate();
        else
            category.Deactivate();
    }
}
