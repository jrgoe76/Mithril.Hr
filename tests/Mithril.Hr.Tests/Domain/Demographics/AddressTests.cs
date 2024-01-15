using FluentAssertions;
using Mithril.Hr.Domain.Demographics;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Demographics;

public sealed class AddressTests
{
    [Fact]
    public void ThrowsArgumentExceptionCausedByAddressLine1()
    {
        ((Func<Address>)(() => new Address(null!, "Tampa", "FL", "12345")))
            .Should().Throw<ArgumentException>();
        ((Func<Address>)(() => new Address(string.Empty, "Tampa", "FL", "12345")))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ThrowsArgumentExceptionCausedByCity()
    {
        ((Func<Address>)(() => new Address("123 Main St", null!, "FL", "12345")))
            .Should().Throw<ArgumentException>();
        ((Func<Address>)(() => new Address("123 Main St", string.Empty, "FL", "12345")))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ThrowsArgumentExceptionCausedByState()
    {
        ((Func<Address>)(() => new Address("123 Main St", "Tampa", null!, "12345")))
            .Should().Throw<ArgumentException>();
        ((Func<Address>)(() => new Address("123 Main St", "Tampa", string.Empty, "12345")))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ThrowsArgumentExceptionCausedByZipcode()
    {
        ((Func<Address>)(() => new Address("123 Main St", "Tampa", "FL", null!)))
            .Should().Throw<ArgumentException>();
        ((Func<Address>)(() => new Address("123 Main St", "Tampa", "FL", string.Empty)))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ReturnsRepresentationWithoutAddressLine2()
    {
        new Address("123 Main St", "Tampa", "FL", "12345").ToString()
            .Should().Be("123 Main St, Tampa, FL 12345");
    }

    [Fact]
    public void ReturnsRepresentation()
    {
        new Address("123 Main St", "Apt B", "Tampa", "FL", "12345").ToString()
            .Should().Be("123 Main St Apt B, Tampa, FL 12345");
    }
}
