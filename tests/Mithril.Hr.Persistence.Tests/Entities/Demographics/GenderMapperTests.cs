using FluentAssertions;
using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Persistence.Entities.Demographics;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Demographics;

public sealed class GenderMapperTests
{
	[Theory]
    [InlineData((char)GenderMapper.Codes.Male, Gender.Values.Male)]
	[InlineData((char)GenderMapper.Codes.Female, Gender.Values.Female)]
    internal void Maps_a_Code_into_its_Gender(char code, Gender.Values gender)
	{
		new GenderMapper().Map(code).Value
			.Should().Be(gender);
	}

	[Theory]
	[InlineData(nameof(Gender.Values.Male), (char)GenderMapper.Codes.Male)]
	[InlineData(nameof(Gender.Values.Female), (char)GenderMapper.Codes.Female)]
    public void Maps_a_Gender_into_its_Code(string gender, char code)
    {
        new GenderMapper().MapCode(new Gender(gender))
            .Should().Be(code);
    }
}
