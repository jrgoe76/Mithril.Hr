﻿using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mithril.Hr.Domain.Education;
using System.Diagnostics.CodeAnalysis;

namespace Mithril.Hr.Persistence.Entities.Education;

[ExcludeFromCodeCoverage]
internal sealed class AcademicDegreeConverter(
        AcademicDegreeMapper academicDegreeMapper) : ValueConverter<AcademicDegree, string>(
    academicDegree => academicDegreeMapper.MapCode(academicDegree),
    code => academicDegreeMapper.MapAcademicDegree(code));