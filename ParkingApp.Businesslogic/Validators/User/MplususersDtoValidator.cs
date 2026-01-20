
using ParkingApp.Infrastructure.DTO.Master;
using ParkingApp.Infrastructure.DTO.User;

public class MplususersDtoValidator : BaseValidator<MplususersDto>
{
    public MplususersDtoValidator()
    {
        NotEmptyRule(x => x.UserName, "User Name");
        MaxLengthRule(x => x.UserName, 100, "User Name");
        NotEmptyRule(x => x.UserCode, "User Code");
    }
}
