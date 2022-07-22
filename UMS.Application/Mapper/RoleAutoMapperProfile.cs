using AutoMapper;
using UMS.Application.DTO;
using UMS.Domain.Models;

namespace UMS.Application.Mapper;

public class RoleAutoMapperProfile : Profile
{
    public RoleAutoMapperProfile()
    {
        CreateMap<Domain.Models.Role, RoleDTO>();
    }
}