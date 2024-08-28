using Application.Abstractions.Repositories.Common;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Queries.Roles.GetRoles;

public class GetRolesQueryHandler(RoleManager<Role> roleManager, IMapper mapper)
    : IRequestHandler<GetRolesQuery, GetRolesQueryResponse>
{
    public async Task<GetRolesQueryResponse> Handle(GetRolesQuery request,
        CancellationToken cancellationToken)
    {
        var exceptRoles = new List<string>() { "Admin", "User" };
        var roles = roleManager.Roles.Where(r => !exceptRoles.Contains(r.Name)).ToList();
        var rolesDto = mapper.Map<IReadOnlyList<RoleDto>>(roles);
        return await Task.FromResult(new GetRolesQueryResponse(rolesDto));
    }
}