
using ParkingApp.Infrastructure.DTO.Master;

public class RolemenumappingDtoValidator : BaseValidator<RolemenumappingDto>
{
    public RolemenumappingDtoValidator()
    {
        NotEmptyRule(x => x.Roleid, "Role Id");
        NotEmptyRule(x => x.Menuid, "Menu Id");
    }
}
