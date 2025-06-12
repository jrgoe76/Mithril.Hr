using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Application.Tests.Seeds.Employees;
using Mithril.Hr.Infrastructure.Persistence.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Api.Tests.Controllers;

public sealed class EmployeesControllerTests : IntegrationTestBase
{
    [Fact]
    public async Task Returns_all_Employees()
    {
        var liamHill = EmployeeEfSeed.LiamHill();
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
    public async Task Returns_an_Employee_by_its_Id()
    {
        var liamHill = EmployeeEfSeed.LiamHill();
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
    public async Task Adds_an_Employee()
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
    public async Task Updates_an_Employee()
    {
        var dianaKingEf = EmployeeEfSeed.DianaKing();
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