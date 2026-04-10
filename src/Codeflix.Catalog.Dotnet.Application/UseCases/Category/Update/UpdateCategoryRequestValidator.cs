using FluentValidation;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.Update;

public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryRequestValidator()
        => RuleFor(x => x.Id).NotEmpty();
}
