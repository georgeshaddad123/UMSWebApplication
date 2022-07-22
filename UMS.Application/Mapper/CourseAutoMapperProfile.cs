using AutoMapper;
using UMS.Application.DTO;

namespace UMS.Application.Mapper;

public class CourseAutoMapperProfile : Profile

{
    public CourseAutoMapperProfile()
    {
        CreateMap<Domain.Models.Course, CourseDTO>()
            .ForMember(dest =>dest.Start,
                opt => 
                    opt.MapFrom(src => src.EnrolmentDateRange.Value.LowerBound.ToDateTime(TimeOnly.MinValue)))
            .ForMember(dest =>dest.End,
                opt => 
                opt.MapFrom(src => src.EnrolmentDateRange.Value.UpperBound.ToDateTime(TimeOnly.MaxValue)));
    }
}