using AutoMapper;
using UMS.Application.DTO;
using UMS.Domain.Models;

namespace UMS.Application.Mapper;

public class UserAutoMapperProfile :Profile
{
    public UserAutoMapperProfile()
    {
        CreateMap<Domain.Models.User, UserDTO>();
    }
}