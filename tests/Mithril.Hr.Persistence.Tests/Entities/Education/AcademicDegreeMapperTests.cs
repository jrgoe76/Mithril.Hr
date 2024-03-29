﻿using FluentAssertions;
using Mithril.Hr.Domain.Education;
using Mithril.Hr.Persistence.Entities.Education;
using Xunit;

namespace Mithril.Hr.Persistence.Tests.Entities.Education;

public sealed class AcademicDegreeMapperTests
{
    [Fact]
    public void MapsAcademicDegree()
    {
        new AcademicDegreeMapper().Map(AcademicDegreeMapper.Codes.Associate)
            .Should().Be(AcademicDegree.Associate);
        new AcademicDegreeMapper().Map(AcademicDegreeMapper.Codes.Bachelor)
            .Should().Be(AcademicDegree.Bachelor);
        new AcademicDegreeMapper().Map(AcademicDegreeMapper.Codes.Master)
            .Should().Be(AcademicDegree.Master);
        new AcademicDegreeMapper().Map(AcademicDegreeMapper.Codes.PhD)
            .Should().Be(AcademicDegree.PhD);
    }

    [Fact]
    public void MapsCode()
    {
	    new AcademicDegreeMapper().MapCode(AcademicDegree.Associate)
		    .Should().Be(AcademicDegreeMapper.Codes.Associate);
	    new AcademicDegreeMapper().MapCode(AcademicDegree.Bachelor)
		    .Should().Be(AcademicDegreeMapper.Codes.Bachelor);
	    new AcademicDegreeMapper().MapCode(AcademicDegree.Master)
		    .Should().Be(AcademicDegreeMapper.Codes.Master);
	    new AcademicDegreeMapper().MapCode(AcademicDegree.PhD)
		    .Should().Be(AcademicDegreeMapper.Codes.PhD);
    }
}
