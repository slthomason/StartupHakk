namespace VerticalSlicedMinimalApi.Application.Company.GetCompanyById;

public record GetCompanyByIdResponse(Guid Id, string Name, string Country, string CompanySize);