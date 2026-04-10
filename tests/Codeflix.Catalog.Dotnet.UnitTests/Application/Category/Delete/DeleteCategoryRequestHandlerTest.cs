using Codeflix.Catalog.Dotnet.Application.Exceptions;
using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Delete;
using FluentAssertions;
using Moq;

namespace Codeflix.Catalog.Dotnet.UnitTests.Application.Category.Delete;

[Collection(nameof(DeleteCategoryTestFixture))]
public class DeleteCategoryRequestHandlerTest(DeleteCategoryTestFixture fixture)
{

    [Fact(DisplayName = nameof(DeleteCategory))]
    [Trait("Application", "DeleteCategory - Use Cases")]
    public async Task DeleteCategory()
    {
        var repositoryMock = fixture.GetRepositoryMock();
        var unitOfWorkMock = fixture.GetUnitOfWorkMock();
        var categoryExample = fixture.GetExampleCategory();
        repositoryMock.Setup(x => x.Get(
            categoryExample.Id,
            It.IsAny<CancellationToken>())
        ).ReturnsAsync(categoryExample);
        var request = new DeleteCategoryRequest(categoryExample.Id);
        var useCase = new DeleteCategoryRequestHandler(
            repositoryMock.Object,
            unitOfWorkMock.Object);

        await useCase.Handle(request, CancellationToken.None);

        repositoryMock.Verify(x => x.Get(
            categoryExample.Id,
            It.IsAny<CancellationToken>()
        ), Times.Once);
        repositoryMock.Verify(x => x.Delete(
            categoryExample,
            It.IsAny<CancellationToken>()
        ), Times.Once);
        unitOfWorkMock.Verify(x => x.Commit(
            It.IsAny<CancellationToken>()
        ), Times.Once);
    }


    [Fact(DisplayName = nameof(ThrowWhenCategoryNotFound))]
    [Trait("Application", "DeleteCategory - Use Cases")]
    public async Task ThrowWhenCategoryNotFound()
    {
        var repositoryMock = fixture.GetRepositoryMock();
        var unitOfWorkMock = fixture.GetUnitOfWorkMock();
        var exampleGuid = Guid.NewGuid();
        repositoryMock.Setup(x => x.Get(
            exampleGuid,
            It.IsAny<CancellationToken>())
        ).ThrowsAsync(
            new NotFoundException($"Category '{exampleGuid}' not found")
        );
        var Request = new DeleteCategoryRequest(exampleGuid);
        var useCase = new DeleteCategoryRequestHandler(
            repositoryMock.Object,
            unitOfWorkMock.Object);

        var task = async ()
            => await useCase.Handle(Request, CancellationToken.None);

        await task.Should()
            .ThrowAsync<NotFoundException>();

        repositoryMock.Verify(x => x.Get(
            exampleGuid,
            It.IsAny<CancellationToken>()
        ), Times.Once);
    }
}
