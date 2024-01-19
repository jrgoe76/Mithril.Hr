using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Application.Tests.Seeds.Employees;
using Mithril.Hr.Persistence.Tests.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Api.Tests.Controllers;

public sealed class EmployeesControllerTests : IntegrationTestBase
{
    [Fact]
    public async Task GetsAllEmployees()
    {
        var liamHill = EmployeeEfTestSeed.LiamHill();
        var liamHillDetail = EmployeeDetailTestSeed.LiamHill;

        await DbContext.Employees.AddAsync(liamHill);
        await DbContext.SaveChangesAsync();

        var response = await Client.GetAsync("/employees");
        var actual = await GetResult<ICollection<EmployeeDetail>>(response);

        response.IsSuccessStatusCode
            .Should().BeTrue();
        actual
            .Should().BeEquivalentTo(new[] { liamHillDetail });
    }

    [Fact]
    public async Task GetsEmployeeById()
    {
        var liamHill = EmployeeEfTestSeed.LiamHill();
        var liamHillInfo = EmployeeInfoTestSeed.LiamHill;

        await DbContext.Employees.AddAsync(liamHill);
        await DbContext.SaveChangesAsync();

        var response = await Client.GetAsync($"/employees/{liamHill.EmployeeId}");
        var actual = await GetResult<EmployeeInfo>(response);

        response.IsSuccessStatusCode
            .Should().BeTrue();
        actual
            .Should().Be(liamHillInfo);
    }

    [Fact]
    public async Task AddsEmployee()
    {
        var paulaCarrAddInfo = AddEmployeeInfoSeed.PaulaCarr;

        var response = await Client.PostAsync("/employees", GetContent(paulaCarrAddInfo));
        var actual = await GetResult<EmployeeInfo>(response);

        response.IsSuccessStatusCode
            .Should().BeTrue();
        actual.EmployeeId
            .Should().NotBeEmpty();
        actual.FirstName
            .Should().Be(paulaCarrAddInfo.FirstName);
    }

    [Fact]
    public async Task UpdatesEmployee()
    {
	    var dianaKingEf = EmployeeEfTestSeed.DianaKing();
        var dianaKingUpdateInfo = UpdateEmployeeInfoTestSeed.DianaKing;

        await DbContext.Employees.AddAsync(dianaKingEf);
        await DbContext.SaveChangesAsync();

        var response = await Client.PutAsync("/employees", GetContent(dianaKingUpdateInfo));
        var actual = await GetResult<EmployeeInfo>(response);

        response.IsSuccessStatusCode
            .Should().BeTrue();
        actual.FirstName
            .Should().Be(dianaKingUpdateInfo.FirstName);
    }
}
