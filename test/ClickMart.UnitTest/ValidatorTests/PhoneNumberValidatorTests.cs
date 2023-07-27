using ClickMart.Service.Validators;

namespace ClickMart.UnitTest.ValidatorTests;

public class PhoneNumberValidatorTests
{
    [Theory]
    [InlineData("+998331211314")]
    [InlineData("+998331211315")]
    [InlineData("+998661211314")]
    [InlineData("+998331211304")]
    [InlineData("+998941211314")]
    [InlineData("+998331211344")]
    [InlineData("+998331211514")]
    [InlineData("+998901211314")]
    [InlineData("+998991211314")]

    public void ShouldReturnCorrect(string phoneNumber)
    {
        var result = PhoneNumberValidator.IsValid(phoneNumber);
        Assert.True(result);
    }
}
