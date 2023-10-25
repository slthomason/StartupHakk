namespace VerticalSlicedMinimalApi.Infrastructure.DataStore;

public record CompanyData(Guid Id, string Name, string Country, string Address, string CompanySize, DateTime LastModified);

public class FakeDbContext
{
    private static List<CompanyData> _companies = new();

    public FakeDbContext()
    {
        _companies = new List<CompanyData>
        {
            new(new Guid("7a6632a4-9576-4b8b-bc42-b730fe5f0f93"), "Company One Co.", "United States","Somewhere","Medium", DateTime.Now),
            new(new Guid("6ea3831f-7dbc-4273-8462-92111c33438c"), "Company Two Co.", "United States","Somewhere","Large", DateTime.Now),
            new(new Guid("a5d058b7-b562-4857-854a-d991b302822a"), "Company Three Co.", "United States","Somewhere","Small", DateTime.Now),
            new(new Guid("8e1dad0d-b379-4c2d-bb53-b0cdb5bdd789"), "A Fantastic Co.", "United States","Somewhere","Medium", DateTime.Now),
        };
    }

    public async Task<IQueryable<CompanyData>> Companies() => await Task.FromResult(_companies.AsQueryable());
}