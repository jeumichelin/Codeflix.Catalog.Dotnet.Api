using Codeflix.Catalog.Dotnet.UnitTests.Application.Category.Common;

namespace Codeflix.Catalog.Dotnet.UnitTests.Application.Category.Delete;

[CollectionDefinition(nameof(DeleteCategoryTestFixture))]
public class DeleteCategoryTestFixtureCollection : ICollectionFixture<DeleteCategoryTestFixture>
{

}

public class DeleteCategoryTestFixture
    : CategoryUseCasesBaseFixture
{ }