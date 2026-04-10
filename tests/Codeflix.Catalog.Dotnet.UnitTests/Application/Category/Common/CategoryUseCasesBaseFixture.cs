using Codeflix.Catalog.Dotnet.Application.Interfaces;
using Codeflix.Catalog.Dotnet.Domain.Repository.Interfaces;
using Codeflix.Catalog.Dotnet.UnitTests.Common;
using Moq;
using DomainEntity = Codeflix.Catalog.Dotnet.Domain.Entities;

namespace Codeflix.Catalog.Dotnet.UnitTests.Application.Category.Common;

public abstract class CategoryUseCasesBaseFixture : BaseFixture
{
public Mock<ICategoryRepository> GetRepositoryMock()
        => new();

    public Mock<IUnitOfWork> GetUnitOfWorkMock()
        => new();

    public string GetValidCategoryName()
    {
        var categoryName = "";
        while (categoryName.Length < 3)
            categoryName = Faker.Commerce.Categories(1)[0];
        if (categoryName.Length > 255)
            categoryName = categoryName[..255];
        return categoryName;
    }

    public string GetValidCategoryDescription()
    {
        var categoryDescription =
            Faker.Commerce.ProductDescription();
        if (categoryDescription.Length > 10_000)
            categoryDescription =
                categoryDescription[..10_000];
        return categoryDescription;
    }
}
