using FluentAssertions;
using Mithril.Hr.Domain.Seeds.Employees;
using Mithril.Hr.Infrastructure.Persistence.Model.Demographics;
using Mithril.Hr.Infrastructure.Persistence.Model.Education;
using Mithril.Hr.Infrastructure.Persistence.Model.Employees;
using Mithril.Hr.Infrastructure.Persistence.Seeds.Employees;
using Mithril.Hr.Infrastructure.Tests.Helpers;
using Xunit;

namespace Mithril.Hr.Infrastructure.Tests.Persistence.Model.Employees;

public sealed class GetEmployeeByIdQueryTests
{
    [Fact]
    public async Task Returns_an_Employee_by_its_Id()
    {
        var liamHill = EmployeeSeed.LiamHill();
        var liamHillEf = EmployeeEfSeed.LiamHill();
        var dianaKingEf = EmployeeEfSeed.DianaKing();

        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();

        await dbContext.Employees.AddRangeAsync(liamHillEf, dianaKingEf);
        await dbContext.SaveChangesAsync();

        (await new GetEmployeeByIdQuery(
                    dbContext,
                    new EmployeeMapper(new GenderMapper(), new AcademicDegreeMapper()))
                .Get(liamHillEf.EmployeeId))
            .Should().Be(liamHill);
    }
}