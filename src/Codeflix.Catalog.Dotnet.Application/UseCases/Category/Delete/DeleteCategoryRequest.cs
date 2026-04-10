using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Common;
using MediatR;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.Delete;

public class DeleteCategoryRequest(Guid id) : IRequest<CategoryModelResponse>
{
    public Guid Id { get; set; } = id;
}
