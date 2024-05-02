using FluentAssertions;
using Mithril.Hr.Domain.Demographics;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Demographics;

public sealed class AddressTests
{
	private const string _addressLine1 = "123 Main St";
	private const string _city = "Tampa";
	private const string _state = "FL";
	private const string _zipcode = "12345";

	[Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Throws_an_error_caused_by_a_null_or_empty_AddressLine1(string? addressLine1)
    {
        ((Func<Address>)(() => new Address(addressLine1!, _city, _state, _zipcode)))
            .Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Throws_an_error_caused_by_a_null_or_empty_City(string? city)
    {
        ((Func<Address>)(() => new Address(_addressLine1, city!, _state, _zipcode)))
            .Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Throws_an_error_caused_by_a_null_or_empty_State(string? state)
    {
        ((Func<Address>)(() => new Address(_addressLine1, _city, state!, _zipcode)))
            .Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void Throws_an_error_caused_by_a_null_or_empty_Zipcode(string? zipCode)
    {
        ((Func<Address>)(() => new Address(_addressLine1, _city, _state, zipCode!)))
            .Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData("123 Main St", "Tampa", "FL", "12345",
        "123 Main St, Tampa, FL 12345")]
    [InlineData("374 Madison Ave", "York", "PA", "43848",
        "374 Madison Ave, York, PA 43848")]
    [InlineData("645 Beach St", "St Petersburg", "FL", "37475",
        "645 Beach St, St Petersburg, FL 37475")]
    public void Returns_the_representation_without_AddressLine2(
        string addressLine1, string city, string state, string zipcode,
        string representation)
    {
        new Address(addressLine1, city, state, zipcode).ToString()
	        .Should().Be(representation);
    }

    [Theory]
    [InlineData("123 Main St", "Apt B", "Tampa", "FL", 
        "12345", "123 Main St Apt B, Tampa, FL 12345")]
    [InlineData("374 Madison Ave", "Apt 32", "York", "PA", "43848",
        "374 Madison Ave Apt 32, York, PA 43848")]
    [InlineData("645 Beach St", "Apt 2003", "St Petersburg", "FL", "37475",
        "645 Beach St Apt 2003, St Petersburg, FL 37475")]
    public void Returns_the_representation(
        string addressLine1, string addressLine2, string city, string state, string zipcode,
        string representation)
    {
        new Address(addressLine1, addressLine2, city, state, zipcode).ToString()
            .Should().Be(representation);
    }
}
