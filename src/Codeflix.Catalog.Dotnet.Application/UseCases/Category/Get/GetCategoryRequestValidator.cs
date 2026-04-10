using FluentValidation;

namespace Codeflix.Catalog.Dotnet.Application.UseCases.Category.Get;

public class GetCategoryRequestValidator : AbstractValidator<GetCategoryRequest>
{
    
    public GetCategoryRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id should not be empty");
    }
}
