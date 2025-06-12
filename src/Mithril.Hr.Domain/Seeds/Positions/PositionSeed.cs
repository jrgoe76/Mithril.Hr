using Mithril.Hr.Domain.Model.Positions;

namespace Mithril.Hr.Domain.Seeds.Positions;

public static class PositionSeed
{
    public static Position ChiefExecutiveOfficer() => new("CEO", "Chief Executive Officer");

    public static Position ChiefOperatingOfficer() => new("COO", "Chief Operating Officer");
    public static Position StoreManager() => new("STR_MGR", "Store Manager");
    public static Position SectionLeader() => new("SEC_LED", "Section Leader");
    public static Position StockAssistant() => new("STK_AST", "Stock Assistant");

    public static Position ChiefFinancialOfficer() => new("CFO", "Chief Financial Officer");
    public static Position AccountingManager() => new("ACT_MGR", "Accounting Manager");
    public static Position Accountant() => new("ACT", "Accountant");
}