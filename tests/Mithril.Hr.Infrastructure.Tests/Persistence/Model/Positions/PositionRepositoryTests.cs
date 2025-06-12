using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Domain.Seeds.Positions;
using Mithril.Hr.Infrastructure.Persistence.Model.Positions;
using Mithril.Hr.Infrastructure.Tests.Helpers;
using Xunit;

namespace Mithril.Hr.Infrastructure.Tests.Persistence.Model.Positions;

public sealed class PositionRepositoryTests
{
	[Fact]
	public async Task Adds_Position_into_DbContext()
	{
		using var dbContextFactory = DbContextTestFactory.New();
		await using var dbContext = dbContextFactory.Create();

		await new PositionRepository(dbContext).Add(PositionSeed.ChiefExecutiveOfficer);

		(await dbContext.Positions.FirstAsync()).Version
			.Should().NotBeEmpty();
		dbContext.ChangesAreSaved
			.Should().BeTrue();
	}
}
