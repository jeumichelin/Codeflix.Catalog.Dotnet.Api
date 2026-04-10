using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Common;
using Codeflix.Catalog.Dotnet.Domain.Repository.Interfaces;
using MediatR;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.List;

public class ListCategoriesRequestHandler(ICategoryRepository categoryRepository) : IRequestHandler<ListCategoriesRequest, ListCategoriesResponse>
{
    public async Task<ListCategoriesResponse> Handle(ListCategoriesRequest request, CancellationToken cancellationToken)
    {
        var searchOutput = await categoryRepository.Search(
            new(
                request.Page, 
                request.PerPage, 
                request.Search, 
                request.Sort, 
                request.Dir
            ),
            cancellationToken
        );

        return new ListCategoriesResponse(
            searchOutput.CurrentPage,
            searchOutput.PerPage,
            searchOutput.Total,
            searchOutput.Items
                .Select(CategoryModelResponse.FromCategory)
                .ToList()
        );
    }
}
