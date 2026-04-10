using Codeflix.Catalog.Dotnet.Application.Exceptions;
using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Get;
using FluentAssertions;
using Moq;

namespace Codeflix.Catalog.Dotnet.UnitTests.Application.Category.Get;

[Collection(nameof(GetCategoryTestFixture))]
public class GetCategoryRequestHandlerTest(GetCategoryTestFixture fixture)
{
    [Fact(DisplayName = nameof(GetCategory))]
    [Trait("Application", "GetCategory - Use Cases")]
    public async Task GetCategory()
    {
        var repositoryMock = fixture.GetRepositoryMock();
        var exampleCategory = fixture.GetExampleCategory();
        repositoryMock.Setup(x => x.Get(
            It.IsAny<Guid>(),
            It.IsAny<CancellationToken>()
        )).ReturnsAsync(exampleCategory);
        var Request = new GetCategoryRequest(exampleCategory.Id);
        var useCase = new GetCategoryRequestHandler(repositoryMock.Object);

        var output = await useCase.Handle(Request, CancellationToken.None);

        repositoryMock.Verify(x => x.Get(
            It.IsAny<Guid>(),
            It.IsAny<CancellationToken>()
        ), Times.Once);

        output.Should().NotBeNull();
        output.Name.Should().Be(exampleCategory.Name);
        output.Description.Should().Be(exampleCategory.Description);
        output.IsActive.Should().Be(exampleCategory.IsActive);
        output.Id.Should().Be(exampleCategory.Id);
        output.CreatedAt.Should().Be(exampleCategory.CreatedAt);
    }

    [Fact(DisplayName = nameof(NotFoundExceptionWhenCategoryDoesntExist))]
    [Trait("Application", "GetCategory - Use Cases")]
    public async Task NotFoundExceptionWhenCategoryDoesntExist()
    {
        var repositoryMock = fixture.GetRepositoryMock();
        var exampleGuid = Guid.NewGuid();
        repositoryMock.Setup(x => x.Get(
            It.IsAny<Guid>(),
            It.IsAny<CancellationToken>()
        )).ThrowsAsync(
            new NotFoundException($"Category '{exampleGuid}' not found")
        );
        var Request = new GetCategoryRequest(exampleGuid);
        var useCase = new GetCategoryRequestHandler(repositoryMock.Object);

        var task = async ()
            => await useCase.Handle(Request, CancellationToken.None);

        await task.Should().ThrowAsync<NotFoundException>();
        repositoryMock.Verify(x => x.Get(
            It.IsAny<Guid>(),
            It.IsAny<CancellationToken>()
        ), Times.Once);
    }
}