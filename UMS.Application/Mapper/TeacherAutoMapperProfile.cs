using AutoMapper;
using UMS.Application.DTO;

namespace UMS.Application.Mapper;

public class TeacherAutoMapperProfile : Profile
{
    public TeacherAutoMapperProfile()
    {
        CreateMap<Domain.Models.TeacherPerCourse, TeacherDTO>();
    }
}