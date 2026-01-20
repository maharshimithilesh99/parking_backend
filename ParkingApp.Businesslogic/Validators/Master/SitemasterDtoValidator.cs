
using ParkingApp.Infrastructure.DTO.Master;

public class SitemasterDtoValidator : BaseValidator<SitemasterDto>
{
    public SitemasterDtoValidator()
    {
        NotEmptyRule(x => x.Companyid, "Company");
        NotEmptyRule(x => x.Sitename, "Site name");
        NotEmptyRule(x => x.Sitecode, "Site code");
    }
}
