using FluentAssertions;
using Mithril.Hr.Application.Features.Positions;
using Mithril.Hr.Application.Seeds.Positions;
using Mithril.Hr.Domain.Positions;
using Mithril.Hr.Seeds.Positions;
using Moq;
using Xunit;

namespace Mithril.Hr.Application.Tests.Features.Positions;

public sealed class AddPositionFeatureTests
{
	private readonly Position _ceo = PositionSeed.ChiefExecutiveOfficer;
    private readonly PositionInfo _ceoInfo = PositionInfoSeed.ChiefExecutiveOfficer;

    private readonly Mock<IPositionRepository> _positionRepositoryMock = new ();

    [Fact]
    public async Task ReturnsPositionInfo()
    {
        (await GetFeature().Add(_ceoInfo))
            .Should().Be(_ceoInfo);
    }

    [Fact]
    public async Task AddsPositionToRepository()
    {
        await GetFeature().Add(_ceoInfo);

        _positionRepositoryMock
            .Verify(repository => repository.Add(_ceo), Times.Once);
    }

    private AddPositionFeature GetFeature()
        => new(_positionRepositoryMock.Object);
}
