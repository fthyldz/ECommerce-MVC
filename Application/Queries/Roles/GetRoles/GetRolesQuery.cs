using MediatR;

namespace Application.Queries.Roles.GetRoles;

public record GetRolesQuery : IRequest<GetRolesQueryResponse>;