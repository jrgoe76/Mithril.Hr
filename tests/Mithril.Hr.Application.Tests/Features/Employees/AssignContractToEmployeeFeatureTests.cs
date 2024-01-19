﻿using FluentAssertions;
using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Application.Seeds.Employees;
using Mithril.Hr.Domain.Employees;
using Mithril.Hr.Domain.Positions;
using Mithril.Hr.Seeds.Employees;
using Mithril.Hr.Seeds.Positions;
using Mithril.Hr.Tests.Seeds.Employees;
using Moq;
using Xunit;

namespace Mithril.Hr.Application.Tests.Features.Employees;

public sealed class AssignContractToEmployeeFeatureTests
{
    private static readonly DateOnly _today = DateOnly.FromDateTime(DateTime.Today);

    private readonly Position _position = PositionSeed.ChiefFinancialOfficer;
    private readonly Employee _dianaKing = EmployeeSeed.DianaKing();
    private readonly Employee _dianaKingWithContract = EmployeeTestSeed.DianaKingWithContract(_today);

    private readonly Mock<IGetEmployeeByIdQuery> _getEmployeeByIdQueryMock = new ();
    private readonly Mock<IGetPositionByCodeQuery> _getPositionByCodeQueryMock = new ();
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new ();
    private readonly EmployeeInfoMapper _employeeInfoMapper = new ();

    [Fact]
    public async Task ReturnsEmployeeInfo()
    {
        var dianaKingInfoWithContract = _employeeInfoMapper
            .Map(_dianaKingWithContract);

        _getEmployeeByIdQueryMock.Setup(_dianaKing);
        _getPositionByCodeQueryMock.Setup(_position);

        (await GetFeature().Assign(AssignContractInfoSeed.DianaKing(_today)))
            .Should().Be(dianaKingInfoWithContract);
    }

    [Fact]
    public async Task UpdatesEmployeeInRepository()
    {
        _getEmployeeByIdQueryMock.Setup(_dianaKing);
        _getPositionByCodeQueryMock.Setup(_position);

        await GetFeature().Assign(AssignContractInfoSeed.DianaKing(_today));

        _employeeRepositoryMock
            .Verify(repository => repository.Update(_dianaKingWithContract), Times.Once);
    }

    private AssignContractToEmployeeFeature GetFeature()
	    => new (
		    _getEmployeeByIdQueryMock.Object,
		    _getPositionByCodeQueryMock.Object,
		    _employeeRepositoryMock.Object,
		    _employeeInfoMapper);
}
