namespace Application.Queries.Roles.GetRoles;

public record GetRolesQueryResponse(IReadOnlyList<RoleDto> Roles);

public record RoleDto(Guid Id, string Name);