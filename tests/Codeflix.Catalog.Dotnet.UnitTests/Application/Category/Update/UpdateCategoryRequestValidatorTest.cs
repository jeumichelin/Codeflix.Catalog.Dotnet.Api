using Codeflix.Catalog.Dotnet.Application.UseCases.Category.Update;
using FluentAssertions;
using FluentValidation;

namespace Codeflix.Catalog.Dotnet.UnitTests.Application.Category.Update;

[Collection(nameof(UpdateCategoryTestFixture))]
public class UpdateCategoryRequestValidatorTest(UpdateCategoryTestFixture fixture)
{
    [Fact(DisplayName = nameof(DontValidateWhenEmptyGuid))]
    [Trait("Application", "UpdateCategoryRequestValidator - Use Cases")]
    public void DontValidateWhenEmptyGuid()
    {
        ValidatorOptions.LanguageManager.Enabled = false;
        var input = fixture.GetValidInput(Guid.Empty);
        var validator = new UpdateCategoryRequestValidator();

        var validateResult = validator.Validate(input);

        validateResult.Should().NotBeNull();
        validateResult.IsValid.Should().BeFalse();
        validateResult.Errors.Should().HaveCount(1);
        validateResult.Errors[0].ErrorMessage
            .Should().Be("'Id' must not be empty.");
    }


    [Fact(DisplayName = nameof(ValidateWhenValid))]
    [Trait("Application", "UpdateCategoryRequestValidator - Use Cases")]
    public void ValidateWhenValid()
    {
        var input = fixture.GetValidInput();
        var validator = new UpdateCategoryRequestValidator();

        var validateResult = validator.Validate(input);

        validateResult.Should().NotBeNull();
        validateResult.IsValid.Should().BeTrue();
        validateResult.Errors.Should().HaveCount(0);
    }
}
