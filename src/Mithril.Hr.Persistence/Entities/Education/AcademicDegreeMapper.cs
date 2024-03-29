﻿using Mithril.Hr.Domain.Education;

namespace Mithril.Hr.Persistence.Entities.Education;

public sealed class AcademicDegreeMapper
{
    internal static class Codes
    {
        public static string Associate = "AS";
        public static string Bachelor = "BC";
        public static string Master = "MS";
        public static string PhD = "PD";
    }

    private readonly IDictionary<string, AcademicDegree.Values> _codeToValueDictionary
        = new Dictionary<string, AcademicDegree.Values>
        {
            { Codes.Associate, AcademicDegree.Values.Associate },
            { Codes.Bachelor, AcademicDegree.Values.Bachelor },
            { Codes.Master, AcademicDegree.Values.Master },
            { Codes.PhD, AcademicDegree.Values.PhD }
        };

    public AcademicDegree Map(string code)
	    => new(GetAcademicDegree(code));

    public string MapCode(AcademicDegree academicDegree)
        => GetCode(academicDegree);

    private string GetCode(AcademicDegree academicDegree)
        => _codeToValueDictionary
            .Single(pair => pair.Value == academicDegree.Value)
            .Key;

    private string GetAcademicDegree(string code)
        => _codeToValueDictionary[code].ToString();
}
