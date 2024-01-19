using FluentAssertions;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Tests.Helpers;
using Mithril.Hr.Persistence.Tests.Seeds.Employees;
using Mithril.Hr.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Employees;

public sealed class GetEmployeeByIdQueryTests
{
    [Fact]
    public async Task ReturnsEmployee()
    {
	    var liamHill = EmployeeSeed.LiamHill();
	    var liamHillEf = EmployeeEfTestSeed.LiamHill();

        using var dbContextFactory = DbContextTestFactory.New();
        await using var dbContext = dbContextFactory.Create();


        await dbContext.Employees.AddAsync(liamHillEf);
        await dbContext.SaveChangesAsync();

        (await new GetEmployeeByIdQuery(
		        dbContext,
                new EmployeeMapper(new GenderMapper(), new AcademicDegreeMapper()))
			.Get(liamHillEf.EmployeeId))
            .Should().Be(liamHill);
    }
}
