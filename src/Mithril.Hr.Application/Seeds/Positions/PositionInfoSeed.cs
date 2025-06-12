using Mithril.Hr.Application.Features.Positions;
using Mithril.Hr.Domain.Seeds.Positions;

namespace Mithril.Hr.Application.Seeds.Positions;

public static class PositionInfoSeed
{
    public static PositionInfo ChiefExecutiveOfficer = new(
        PositionSeed.ChiefExecutiveOfficer.PositionCode,
        PositionSeed.ChiefExecutiveOfficer.Name);

    public static PositionInfo ChiefOperatingOfficer = new(
        PositionSeed.ChiefOperatingOfficer.PositionCode,
        PositionSeed.ChiefOperatingOfficer.Name);

    public static PositionInfo StoreManager = new(
        PositionSeed.StoreManager.PositionCode,
        PositionSeed.StoreManager.Name);

    public static PositionInfo SectionLeader = new(
        PositionSeed.SectionLeader.PositionCode,
        PositionSeed.SectionLeader.Name);

    public static PositionInfo StockAssistant = new(
        PositionSeed.StockAssistant.PositionCode,
        PositionSeed.StockAssistant.Name);

    public static PositionInfo ChiefFinancialOfficer = new(
        PositionSeed.ChiefFinancialOfficer.PositionCode,
        PositionSeed.ChiefFinancialOfficer.Name);

    public static PositionInfo AccountingManager = new(
        PositionSeed.AccountingManager.PositionCode,
        PositionSeed.AccountingManager.Name);

    public static PositionInfo Accountant = new(
        PositionSeed.Accountant.PositionCode,
        PositionSeed.Accountant.Name);
}