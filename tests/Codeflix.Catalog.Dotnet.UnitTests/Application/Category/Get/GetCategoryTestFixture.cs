using Codeflix.Catalog.Dotnet.UnitTests.Application.Category.Common;

namespace Codeflix.Catalog.Dotnet.UnitTests.Application.Category.Get;

[CollectionDefinition(nameof(GetCategoryTestFixture))]
public class GetCategoryTestFixtureCollection : ICollectionFixture<GetCategoryTestFixture>
{ }

public class GetCategoryTestFixture : CategoryUseCasesBaseFixture
{
}
