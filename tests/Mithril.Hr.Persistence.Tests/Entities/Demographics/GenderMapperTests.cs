using FluentAssertions;
using Mithril.Hr.Domain.Demographics;
using Mithril.Hr.Persistence.Entities.Demographics;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Demographics;

public sealed class GenderMapperTests
{
	[Fact]
	public void MapsGender()
	{
		new GenderMapper().Map((char)GenderMapper.Codes.Male)
			.Should().Be(Gender.Male);
		new GenderMapper().Map((char)GenderMapper.Codes.Female)
			.Should().Be(Gender.Female);
	}

    [Fact]
    public void MapsCode()
    {
        new GenderMapper().MapCode(Gender.Male)
            .Should().Be((char)GenderMapper.Codes.Male);
        new GenderMapper().MapCode(Gender.Female)
            .Should().Be((char)GenderMapper.Codes.Female);
    }
}
