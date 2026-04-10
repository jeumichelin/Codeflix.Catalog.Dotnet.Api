using System;
using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Common;
using MediatR;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.Get;

public class GetCategoryRequest(Guid id) : IRequest<CategoryModelResponse>
{
    public Guid Id { get; set; } = id;
}
