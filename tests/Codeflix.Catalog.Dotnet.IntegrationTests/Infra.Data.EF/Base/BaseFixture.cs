using Codeflix.Catalog.Dotnet.Infra.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Codeflix.Catalog.Dotnet.IntegrationTests.Infra.Data.EF.Base;

public class BaseFixture
{
    public BaseFixture() 
        => Faker = new Faker("pt_BR");

    protected Faker Faker { get; set; }

    public static CodeflixCatalogDbContext CreateDbContext(string dbName = "integration-tests-db", bool preserveData = false)
    {
        var context = new CodeflixCatalogDbContext(
            new DbContextOptionsBuilder<CodeflixCatalogDbContext>()
            .UseInMemoryDatabase(dbName)
            .Options
        );
        if (preserveData == false)
            context.Database.EnsureDeleted();
        return context;
    }
}