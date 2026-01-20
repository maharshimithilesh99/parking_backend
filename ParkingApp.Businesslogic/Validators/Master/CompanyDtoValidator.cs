
using ParkingApp.Infrastructure.DTO.Master;

public class CompanyDtoValidator : BaseValidator<CompanymasterDto>
{
    public CompanyDtoValidator()
    {
        NotEmptyRule(x => x.CompanyName, "Company Name");
        MaxLengthRule(x => x.CompanyName, 100, "Company Name");
        NotEmptyRule(x => x.CompanyCode, "Company Code");
    }
}
