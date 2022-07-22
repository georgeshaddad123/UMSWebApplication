using MediatR;
using UMS.Application.DTO;

namespace UMS.Application.Teacher.Command.RegisterCourse;

public class RegisterCourseCommand : IRequest<TeacherDTO>
{
    public long TeacherId { get; set; }
    public long CourseId { get; set; }
}