using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Common;
using Codeflix.Catalog.Dotnet.Domain.Repository.Interfaces;
using MediatR;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.Get;

public class GetCategoryRequestHandler(ICategoryRepository repository) : IRequestHandler<GetCategoryRequest, CategoryModelResponse>
{
    public async Task<CategoryModelResponse> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
    {
        var category = await repository.Get(request.Id, cancellationToken);

        return CategoryModelResponse.FromCategory(category);
    }
}
