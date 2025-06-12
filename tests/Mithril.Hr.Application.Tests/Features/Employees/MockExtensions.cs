using Mithril.Hr.Domain.Model;
using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Model.Positions;
using Moq;

namespace Mithril.Hr.Application.Tests.Features.Employees;

internal static class MockExtensions
{
    public static void ArrangeGenerateId(this Mock<IIdGenerator> mock, Guid newId)
        => mock
            .Setup(generator => generator.New())
            .Returns(newId);

    public static void ArrangeGetEmployeeById(this Mock<IGetEmployeeByIdQuery> mock, Employee employee)
        => mock.Setup(query => query.Get(employee.EmployeeId))
            .ReturnsAsync(employee);

    public static void ArrangeGetPositionByCode(this Mock<IGetPositionByCodeQuery> mock, Position position)
        => mock.Setup(query => query.Get(position.PositionCode))
            .ReturnsAsync(position);
}