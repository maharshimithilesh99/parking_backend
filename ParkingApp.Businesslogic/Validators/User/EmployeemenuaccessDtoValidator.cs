
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;

public class EmployeemenuaccessDtoValidator : BaseValidator<EmployeemenuaccessDto>
{
    public EmployeemenuaccessDtoValidator()
    {
        NotEmptyRule(x => x.Userid, "UserId");
        NotEmptyRule(x => x.Menumasterid, "MenuId");
    }
}
