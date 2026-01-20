
using ParkingApp.Infrastructure.DTO.Master;

public class MenumasterDtoValidator : BaseValidator<MenumasterDto>
{
    public MenumasterDtoValidator()
    {
        NotEmptyRule(x => x.Menuname, "Menu Name");
        MaxLengthRule(x => x.Menutype, 100, "Menu Type Name");
    }
}
