using Codeflix.Catalog.Dotnet.Domain.Entities;
using Codeflix.Catalog.Dotnet.Domain.SeedWork.Interfaces;
using Codeflix.Catalog.Dotnet.Domain.SeedWork.SearcheableRepository;

namespace Codeflix.Catalog.Dotnet.Domain.Repository.Interfaces;

public interface ICategoryRepository : IGenericRepository<Category>, ISearchableRepository<Category>
{
}
