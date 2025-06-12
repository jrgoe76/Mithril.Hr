using FluentAssertions;
using Mithril.Hr.Domain.Seeds.Employees;
using Mithril.Hr.Infrastructure.Persistence.Model.Demographics;
using Mithril.Hr.Infrastructure.Persistence.Model.Education;
using Mithril.Hr.Infrastructure.Persistence.Model.Employees;
using Mithril.Hr.Infrastructure.Tests.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Infrastructure.Tests.Persistence.Model.Employees;

public sealed class EmployeeMapperTests
{
    [Fact]
	public void Maps_an_EmployeeEf_into_an_Employee()
	{
        var liamHill = EmployeeSeed.LiamHill();
        var liamHillEf = EmployeeEfTestSeed.LiamHill();

        new EmployeeMapper(
				new GenderMapper(),
				new AcademicDegreeMapper())
			.Map(liamHillEf)
			.Should().Be(liamHill);
	}
}
