namespace Codeflix.Catalog.Dotnet.Domain.SeedWork.SearcheableRepository;

public interface ISearchableRepository<Taggregate> where Taggregate : AggregateRoot
{
    Task<SearchOutput<Taggregate>> Search(SearchInput input, CancellationToken cancellationToken);
}