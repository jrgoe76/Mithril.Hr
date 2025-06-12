using FluentAssertions;
using Mithril.Hr.Domain.Seeds.Employees;
using Mithril.Hr.Domain.Tests.Seeds.Employees;
using Mithril.Hr.Infrastructure.Persistence.Model.Demographics;
using Mithril.Hr.Infrastructure.Persistence.Model.Education;
using Mithril.Hr.Infrastructure.Persistence.Model.Employees;
using Mithril.Hr.Infrastructure.Tests.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Infrastructure.Tests.Persistence.Model.Employees;

public sealed class EmployeeEfTests
{
	[Fact]
	public void Updates_an_Employee()
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

    [Fact]
	public void Updates_an_Employee_with_Contract()
	{
        var today = DateOnly.FromDateTime(DateTime.Today);
        var tomorrow = today.AddDays(1);

        var dianaKing = EmployeeTestSeed.DianaKingWithContract(today, tomorrow);
        var dianaKingEf = EmployeeEfTestSeed.DianaKingWithContract(today, tomorrow);

		var latestVersion = dianaKingEf.Version;
	    var version = Guid.NewGuid();
	    dianaKingEf.Version = version;
		
        new EmployeeEf { EmployeeId = dianaKing.EmployeeId }
			.Update(
				dianaKing,
				new GenderMapper(),
				new AcademicDegreeMapper(),
				version)
			.Should().Be(dianaKingEf);
        latestVersion
	        .Should().NotBe(version);
	}
}
