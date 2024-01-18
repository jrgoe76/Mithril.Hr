using FluentAssertions;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Persistence.Entities.Demographics;
using Mithril.Hr.Persistence.Entities.Education;
using Mithril.Hr.Persistence.Entities.Employees;
using Mithril.Hr.Persistence.Tests.Seeds.Employees;
using Mithril.Hr.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Employees;

public sealed class EmployeeEntityTests
{
	private readonly Employee _liamHill = EmployeeSeed.LiamHill();
	private readonly EmployeeEntity _liamHillEntity = EmployeeEntityTestSeed.LiamHill();

    [Fact]
	public void UpdatesEmployeeEntity()
	{
		new EmployeeEntity { EmployeeId = _liamHill.EmployeeId }
			.Update(
				_liamHill,
				new GenderMapper(),
				new AcademicDegreeMapper())
			.Should().Be(_liamHillEntity);
	}
}
