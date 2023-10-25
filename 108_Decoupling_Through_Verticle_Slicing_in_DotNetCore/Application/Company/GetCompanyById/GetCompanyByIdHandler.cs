using System.Globalization;
using MediatR;
using VerticalSlicedMinimalApi.Infrastructure.DataStore;

namespace VerticalSlicedMinimalApi.Application.Company.GetCompanyById;

internal class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, GetCompanyByIdResponse>
{
    private readonly FakeDbContext _dbContext;

    public GetCompanyByIdHandler(FakeDbContext context)
    {
        _dbContext = context;
    }
    
    public async Task<GetCompanyByIdResponse> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await Task.FromResult(
            _dbContext.Companies()
                .Result
                .FirstOrDefault(c => c.Id == request.Id));

        // Checking if data is null, if yes returning null or a default response.
        if (data == null)
        {
            return null; 
        }
    
        // Mapping data to GetCompanyByIdResponse DTO.
        return new GetCompanyByIdResponse(data.Id, data.Name, data.Country, data.CompanySize);
    }
}
