using Mithril.Hr.Application.Features.Employees;
using Mithril.Hr.Domain.Model.Employees;
using Mithril.Hr.Domain.Seeds.Employees;

namespace Mithril.Hr.Application.Seeds.Employees;

public static class AddEmployeeInfoSeed
{
    private static readonly Employee _liamHill = EmployeeSeed.LiamHill();
    private static readonly Employee _paulaCarr = EmployeeSeed.PaulaCarr();
    private static readonly Employee _dianaKing = EmployeeSeed.DianaKing();

    public static AddEmployeeInfo LiamHill = new(
        _liamHill.Name.FirstName,
        _liamHill.Name.MiddleInitial,
        _liamHill.Name.LastName,
        _liamHill.Gender.ToString(),
        _liamHill.Email.Address,
        _liamHill.Address.AddressLine1,
        _liamHill.Address.AddressLine2,
        _liamHill.Address.City,
        _liamHill.Address.State,
        _liamHill.Address.Zipcode,
        _liamHill.Degree.ToString());

    public static AddEmployeeInfo PaulaCarr = new(
        _paulaCarr.Name.FirstName,
        _paulaCarr.Name.MiddleInitial,
        _paulaCarr.Name.LastName,
        _paulaCarr.Gender.ToString(),
        _paulaCarr.Email.Address,
        _paulaCarr.Address.AddressLine1,
        _paulaCarr.Address.AddressLine2,
        _paulaCarr.Address.City,
        _paulaCarr.Address.State,
        _paulaCarr.Address.Zipcode,
        _paulaCarr.Degree.ToString());

    public static AddEmployeeInfo DianaKing = new(
        _dianaKing.Name.FirstName,
        _dianaKing.Name.MiddleInitial,
        _dianaKing.Name.LastName,
        _dianaKing.Gender.ToString(),
        _dianaKing.Email.Address,
        _dianaKing.Address.AddressLine1,
        _dianaKing.Address.AddressLine2,
        _dianaKing.Address.City,
        _dianaKing.Address.State,
        _dianaKing.Address.Zipcode,
        _dianaKing.Degree.ToString());
}