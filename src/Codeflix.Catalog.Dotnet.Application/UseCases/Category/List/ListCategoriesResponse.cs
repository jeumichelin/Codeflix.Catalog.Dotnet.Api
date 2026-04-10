using Codeflix.Catalog.Dotnet.Application.Common;
using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Common;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.List;

public class ListCategoriesResponse(
    int page, 
    int perPage, 
    int total, 
    IReadOnlyList<CategoryModelResponse> items) 
    : PaginatedListOutput<CategoryModelResponse>(
        page, 
        perPage, 
        total, 
        items)
{
}
