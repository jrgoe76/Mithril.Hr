namespace Mithril.Hr.Domain.Model.Education;

public record AcademicDegree
{
    public static AcademicDegree Associate { get; } = new(nameof(Values.Associate));
    public static AcademicDegree Bachelor { get; } = new(nameof(Values.Bachelor));
    public static AcademicDegree Master { get; } = new(nameof(Values.Master));
    public static AcademicDegree PhD { get; } = new(nameof(Values.PhD));

    internal enum Values { Associate, Bachelor, Master, PhD }

    internal Values Value { get; init; }

    public AcademicDegree(string academicDegree)
    {
        if (IsNotValid(academicDegree, out Values value))
        {
            throw new ArgumentException("The Academic Degree is invalid", nameof(academicDegree));
        }

        Value = value;
    }

    public override string ToString()
        => Value.ToString();

    private static bool IsNotValid(string academicDegree, out Values value)
        => !Enum.TryParse(academicDegree, true, out value);
}