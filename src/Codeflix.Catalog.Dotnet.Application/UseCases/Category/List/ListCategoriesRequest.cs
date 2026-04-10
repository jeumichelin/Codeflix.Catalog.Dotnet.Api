using Codeflix.Catalog.Dotnet.Application.Common;
using Codeflix.Catalog.Dotnet.Domain.SeedWork.SearcheableRepository;
using MediatR;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.List;

public class ListCategoriesRequest(
    int page = 1, 
    int perPage = 15, 
    string search = "", 
    string sort = "", 
    SearchOrder dir = SearchOrder.Asc) 
    : PaginatedListInput(
        page, 
        perPage, 
        search, 
        sort, 
        dir), IRequest<ListCategoriesResponse>
{
}
