
using ParkingApp.Infrastructure.DTO.Master;

public class CompanycontactpersonDtoValidator : BaseValidator<CompanycontactpersonDto>
{
    public CompanycontactpersonDtoValidator()
    {
        NotEmptyRule(x => x.ContactPersonName, "Contact person Name");
        NotEmptyRule(x => x.Designation, "Designation");
        MaxLengthRule(x => x.ContactPersonName, 100, "Company Name");
        EmailRule(x => x.ContactEmail);
        MobileRule(x => x.ContactMobile);
    }
}
