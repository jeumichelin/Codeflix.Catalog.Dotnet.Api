using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Get;
using FluentAssertions;
using FluentValidation;

namespace Codeflix.Catalog.Dotnet.UnitTests.Application.Category.Get;

[Collection(nameof(GetCategoryTestFixture))]
public class GetCategoryRequestValidatorTest()
{

    [Fact(DisplayName = nameof(ValidationOk))]
    [Trait("Application", "GetCategoryRequestValidation - UseCases")]
    public void ValidationOk()
    {
        var validRequest = new GetCategoryRequest(Guid.NewGuid());
        var validator = new GetCategoryRequestValidator();

        var validationResult = validator.Validate(validRequest);

        validationResult.Should().NotBeNull();
        validationResult.IsValid.Should().BeTrue();
        validationResult.Errors.Should().HaveCount(0);
    }

    [Fact(DisplayName = nameof(InvalidWhenEmptyGuidId))]
    [Trait("Application", "GetCategoryRequestValidation - UseCases")]
    public void InvalidWhenEmptyGuidId()
    {
        ValidatorOptions.LanguageManager.Enabled = false;
        var invalidRequest = new GetCategoryRequest(Guid.Empty);
        var validator = new GetCategoryRequestValidator();

        var validationResult = validator.Validate(invalidRequest);

        validationResult.Should().NotBeNull();
        validationResult.IsValid.Should().BeFalse();
        validationResult.Errors.Should().HaveCount(1);
        validationResult.Errors[0].ErrorMessage
            .Should().Be("Id should not be empty");
    }
}
