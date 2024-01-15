using Mithril.Hr.Domain.Positions;

namespace Mithril.Hr.Seeds.Positions;

public static class PositionSeed
{
    public static Position ChiefExecutiveOfficer = new ("CEO", "Chief Executive Officer", 5);

    public static Position ChiefOperatingOfficer = new ("COO", "Chief Operating Officer", 5);
    public static Position StoreManager = new ("STR_MGR", "Store Manager", 10);
    public static Position SectionLeader = new ("SEC_LED", "Section Leader", 5);
    public static Position StockAssistant = new ("STK_AST", "Stock Assistant", 0);

    public static Position ChiefFinancialOfficer = new ("CFO", "Chief Financial Officer", 5);
    public static Position AccountingManager = new ("ACT_MGR", "Accounting Manager", 10);
    public static Position Accountant = new ("ACT", "Accountant", 0);
}
