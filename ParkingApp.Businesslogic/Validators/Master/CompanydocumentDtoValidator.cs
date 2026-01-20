
using ParkingApp.Infrastructure.DTO.Master;

public class CompanydocumentDtoValidator : BaseValidator<CompanydocumentDto>
{
    public CompanydocumentDtoValidator()
    {
        NotEmptyRule(x => x.DocumentName, "Document Name");
    }
}
