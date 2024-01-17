using FluentAssertions;
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
    private static readonly DateOnly Today = DateOnly.FromDateTime(DateTime.Today);

    private readonly Position _position = PositionSeed.ChiefFinancialOfficer;
    private readonly Employee _dianaKing = EmployeeSeed.DianaKing;
    private readonly Employee _dianaKingWithContract = EmployeeTestSeed.DianaKingWithContract(Today);

    private readonly Mock<IGetEmployeeByIdQuery> _getEmployeeByIdQueryMock = new ();
    private readonly Mock<IGetPositionByCodeQuery> _getPositionByCodeQueryMock = new ();
    private readonly Mock<IEmployeeRepository> _employeeRepositoryMock = new ();
    private readonly EmployeeToEmployeeInfoMapper _employeeToEmployeeInfoMapper = new ();

    private readonly AssignContractToEmployeeFeature _feature;

    public AssignContractToEmployeeFeatureTests()
    {
        _feature = new AssignContractToEmployeeFeature(
            _getEmployeeByIdQueryMock.Object,
            _getPositionByCodeQueryMock.Object,
            _employeeRepositoryMock.Object,
            _employeeToEmployeeInfoMapper);
    }

    [Fact]
    public async Task ReturnsEmployeeInfo()
    {
        var dianaKingInfoWithContract = _employeeToEmployeeInfoMapper
            .Map(_dianaKingWithContract);

        _getEmployeeByIdQueryMock.Setup(_dianaKing);
        _getPositionByCodeQueryMock.Setup(_position);

        (await _feature.Assign(AssignContractInfoSeed.DianaKing(Today)))
            .Should().Be(dianaKingInfoWithContract);
    }

    [Fact]
    public async Task UpdatesEmployeeInRepository()
    {
        _getEmployeeByIdQueryMock.Setup(_dianaKing);
        _getPositionByCodeQueryMock.Setup(_position);

        await _feature.Assign(AssignContractInfoSeed.DianaKing(Today));

        _employeeRepositoryMock
            .Verify(repository => repository.Update(_dianaKingWithContract), Times.Once);
    }
}
