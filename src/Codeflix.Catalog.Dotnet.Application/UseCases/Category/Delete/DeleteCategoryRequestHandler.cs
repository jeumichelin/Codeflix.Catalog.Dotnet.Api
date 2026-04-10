using Codeflix.Catalog.Dotnet.Application.Interfaces;
using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Common;
using Codeflix.Catalog.Dotnet.Domain.Repository.Interfaces;
using MediatR;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.Delete;

public class DeleteCategoryRequestHandler(ICategoryRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryRequest, CategoryModelResponse>
{

    public async Task<CategoryModelResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await repository.Get(request.Id, cancellationToken) ?? 
            throw new KeyNotFoundException($"Category '{request.Id}' not found");

        await repository.Delete(category, cancellationToken);

        await unitOfWork.Commit(cancellationToken);

        return CategoryModelResponse.FromCategory(category);
    }
}
