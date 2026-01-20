
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;

public class RolemasterDtoValidator : BaseValidator<RolemasterDto>
{
    public RolemasterDtoValidator()
    {
        NotEmptyRule(x => x.Rolecode, "Role Code");
        MaxLengthRule(x => x.Rolename, 15, "Role Name");
        NotEmptyRule(x => x.Rolename, "Role Name");
    }
}
