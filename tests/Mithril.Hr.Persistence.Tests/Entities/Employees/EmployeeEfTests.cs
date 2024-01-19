using FluentAssertions;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Tests.Seeds.Employees;
using Mithril.Hr.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Employees;

public sealed class EmployeeEfTests
{
    [Fact]
	public void UpdatesEmployee()
	{
		var liamHill = EmployeeSeed.LiamHill();
		var liamHillEf = EmployeeEfTestSeed.LiamHill();

		var latestVersion = liamHillEf.Version;
	    var version = Guid.NewGuid();
	    liamHillEf.Version = version;
		
        new EmployeeEf { EmployeeId = liamHill.EmployeeId }
			.Update(
				liamHill,
				new GenderMapper(),
				new AcademicDegreeMapper(),
				version)
			.Should().Be(liamHillEf);
        latestVersion
	        .Should().NotBe(version);
	}
}
