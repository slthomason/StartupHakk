using MediatR;

namespace VerticalSlicedMinimalApi.Application.Company.GetCompanyById;

public record GetCompanyByIdQuery : IRequest<GetCompanyByIdResponse>
{
    public Guid Id { get; init; }
};