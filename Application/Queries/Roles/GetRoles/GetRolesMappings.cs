using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Queries.Roles.GetRoles;

public class GetRolesMappings : Profile
{
    public GetRolesMappings()
    {
        CreateMap<Role, RoleDto>();
    }
}