using System;

namespace Codeflix.Catalog.Dotnet.Domain.SeedWork.SearcheableRepository;

public class SearchInput(int page, int perPage, string search, string sort, SearchOrder dir)
{
    public int Page { get; set; } = page;
    public int PerPage { get; set; } = perPage;
    public string Search { get; set; } = search;
    public string OrderBy { get; set; } = sort;
    public SearchOrder Order { get; set; } = dir;
}
