using Mithril.Hr.Domain.Model.Positions;
using Mithril.Hr.Domain.Seeds.Positions;
using Mithril.Hr.Infrastructure.Persistence.Model.Positions;

namespace Mithril.Hr.Infrastructure.Persistence.Seeds.Positions;

public static class PositionEfSeed
{
    public static PositionEf ChiefExecutiveOfficer() => Map(PositionSeed.ChiefExecutiveOfficer());

    public static PositionEf ChiefOperatingOfficer() => Map(PositionSeed.ChiefOperatingOfficer());
    public static PositionEf StoreManager() => Map(PositionSeed.StoreManager());
    public static PositionEf SectionLeader() => Map(PositionSeed.SectionLeader());
    public static PositionEf StockAssistant() => Map(PositionSeed.StockAssistant());

    public static PositionEf ChiefFinancialOfficer() => Map(PositionSeed.ChiefFinancialOfficer());
    public static PositionEf AccountingManager() => Map(PositionSeed.AccountingManager());
    public static PositionEf Accountant() => Map(PositionSeed.Accountant());

    private static PositionEf Map(Position position)
        => new(position, Guid.NewGuid());
}