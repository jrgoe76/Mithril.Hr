using FluentAssertions;
using Mithril.Hr.Domain.Education;
using Xunit;

namespace Mithril.Hr.Tests.Domain.Education;

public sealed class AcademicDegreeTests
{
    [Theory]
    [InlineData("Student")]
    [InlineData("Retired")]
    public void Throws_an_error_caused_by_an_invalid_AcademicDegree(string academicDegree)
    {
        ((Func<AcademicDegree>)(() => new AcademicDegree(academicDegree)))
            .Should().Throw<ArgumentException>();
    }

    [Theory]
    [InlineData(nameof(AcademicDegree.Values.Associate))]
    [InlineData(nameof(AcademicDegree.Values.Bachelor))]
    [InlineData(nameof(AcademicDegree.Values.Master))]
    [InlineData(nameof(AcademicDegree.Values.PhD))]
    public void Returns_the_representation(string academicDegree)
    {
        new AcademicDegree(academicDegree).ToString()
            .Should().Be(academicDegree);
    }
}
