using MediatR;
using UMS.Application.DTO;
using UMS.Domain.Models;

namespace UMS.Application.Teacher.Command.TeacherCourseToSessionTime;

public class AddTeacherToSessionTimeCommand : IRequest<TeacherPerCoursePerSessionTime>
{
    public long TeacherPerCId { get; set; }
    public long SessionTId { get; set; }
}