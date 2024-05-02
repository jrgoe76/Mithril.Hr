using FluentAssertions;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Tests.Seeds.Employees;
using Mithril.Hr.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Employees;

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
