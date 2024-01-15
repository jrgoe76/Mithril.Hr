using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Persistence.Seeds.Employees;
using Xunit;

namespace Mithril.Hr.Api.Tests.Controllers;

public sealed class EmployeesControllerTests : IntegrationTestBase
{
    [Fact]
    public async Task GetsAllEmployees()
    {
        await DbContext.Employees.AddAsync(EmployeeEntitySeed.LiamHill);
        await DbContext.SaveChangesAsync();

        var response = await Client.GetAsync("/employees");
        var actual = await GetResult<ICollection<EmployeeDetail>>(response);

        response.IsSuccessStatusCode
            .Should().BeTrue();
        actual
            .Should().BeEquivalentTo(new[] { EmployeeDetailSeed.LiamHill });
    }

    [Fact]
    public async Task GetsEmployeeById()
    {
        await DbContext.Employees.AddAsync(EmployeeEntitySeed.LiamHill);
        await DbContext.SaveChangesAsync();

        var response = await Client.GetAsync($"/employees/{EmployeeEntitySeed.LiamHill.EmployeeId}");
        var actual = await GetResult<EmployeeInfo>(response);

        response.IsSuccessStatusCode
            .Should().BeTrue();
        actual
            .Should().Be(EmployeeInfoSeed.LiamHill);
    }

    [Fact]
    public async Task AddsEmployee()
    {
        var response = await Client.PostAsync("/employees", GetContent(AddEmployeeInfoSeed.PaulaCarr));
        var actual = await GetResult<EmployeeInfo>(response);

        response.IsSuccessStatusCode
            .Should().BeTrue();
        actual.EmployeeId
            .Should().NotBeEmpty();
        actual.FirstName
            .Should().Be(AddEmployeeInfoSeed.PaulaCarr.FirstName);
    }

    [Fact]
    public async Task UpdatesEmployee()
    {
        await DbContext.Employees.AddAsync(EmployeeEntitySeed.DianaKing);
        await DbContext.SaveChangesAsync();

        var response = await Client.PutAsync("/employees", GetContent(UpdateEmployeeInfoSeed.DianaKing));
        var actual = await GetResult<EmployeeInfo>(response);

        response.IsSuccessStatusCode
            .Should().BeTrue();
        actual.FirstName
            .Should().Be(UpdateEmployeeInfoSeed.DianaKing.FirstName);
    }
}
