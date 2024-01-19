using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Mithril.Hr.Persistence.Entities.Positions;
using Mithril.Hr.Persistence.Tests.Helpers;
using Mithril.Hr.Seeds.Positions;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Positions;

public sealed class PositionRepositoryTests
{
	[Fact]
	public async Task AddsPositionIntoDbContext()
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
