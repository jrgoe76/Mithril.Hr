using FluentAssertions;
using Mithril.Hr.Domain.Model.Education;
using Mithril.Hr.Infrastructure.Persistence.Model.Education;
using Xunit;

namespace Mithril.Hr.Infrastructure.Tests.Persistence.Model.Education;

public sealed class AcademicDegreeMapperTests
{
    [Theory]
    [InlineData(AcademicDegreeMapper.Codes.Associate, AcademicDegree.Values.Associate)]
    [InlineData(AcademicDegreeMapper.Codes.Bachelor, AcademicDegree.Values.Bachelor)]
    [InlineData(AcademicDegreeMapper.Codes.Master, AcademicDegree.Values.Master)]
    [InlineData(AcademicDegreeMapper.Codes.PhD, AcademicDegree.Values.PhD)]
    internal void Maps_a_Code_into_its_AcademicDegree(string code, AcademicDegree.Values academicDegree)
    {
        new AcademicDegreeMapper().Map(code).Value
            .Should().Be(academicDegree);
    }

    [Theory]
    [InlineData(nameof(AcademicDegree.Values.Associate), AcademicDegreeMapper.Codes.Associate)]
    [InlineData(nameof(AcademicDegree.Values.Bachelor), AcademicDegreeMapper.Codes.Bachelor)]
    [InlineData(nameof(AcademicDegree.Values.Master), AcademicDegreeMapper.Codes.Master)]
    [InlineData(nameof(AcademicDegree.Values.PhD), AcademicDegreeMapper.Codes.PhD)]
    internal void Maps_an_AcademicDegree_into_its_Code(string academicDegree, string code)
    {
	    new AcademicDegreeMapper().MapCode(new AcademicDegree(academicDegree))
		    .Should().Be(code);
    }
}
