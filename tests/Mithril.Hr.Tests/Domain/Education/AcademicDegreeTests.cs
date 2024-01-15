using FluentAssertions;
using Mithril.Hr.Domain.Education;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Education;

public sealed class AcademicDegreeTests
{
    [Fact]
    public void ThrowsArgumentException()
    {
        ((Func<AcademicDegree>)(() => new AcademicDegree("XXX")))
            .Should().Throw<ArgumentException>();
    }

    [Fact]
    public void ReturnsRepresentation()
    {
        new AcademicDegree(nameof(AcademicDegree.Values.Associate)).ToString()
            .Should().Be(nameof(AcademicDegree.Values.Associate));
        new AcademicDegree(nameof(AcademicDegree.Values.Bachelor)).ToString()
            .Should().Be(nameof(AcademicDegree.Values.Bachelor));
        new AcademicDegree(nameof(AcademicDegree.Values.Master)).ToString()
            .Should().Be(nameof(AcademicDegree.Values.Master));
        new AcademicDegree(nameof(AcademicDegree.Values.PhD)).ToString()
            .Should().Be(nameof(AcademicDegree.Values.PhD));
    }
}
