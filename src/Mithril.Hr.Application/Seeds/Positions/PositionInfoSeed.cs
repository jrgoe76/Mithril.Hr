using Mithril.Hr.Application.Features.Positions;
using Mithril.Hr.Domain.Model.Positions;
using Mithril.Hr.Domain.Seeds.Positions;

namespace Mithril.Hr.Application.Seeds.Positions;

public static class PositionInfoSeed
{
    private static readonly Position _ceo = PositionSeed.ChiefExecutiveOfficer();

    public static PositionInfo ChiefExecutiveOfficer = new(_ceo.PositionCode, _ceo.Name);
}