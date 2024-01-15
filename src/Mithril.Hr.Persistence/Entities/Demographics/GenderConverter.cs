using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mithril.Hr.Domain.Demographics;

namespace Mithril.Hr.Persistence.Entities.Demographics;

[ExcludeFromCodeCoverage]
internal sealed class GenderConverter(
        GenderMapper genderMapper) : ValueConverter<Gender, char>(
    gender => genderMapper.MapCode(gender),
    code => genderMapper.MapGender(code));
