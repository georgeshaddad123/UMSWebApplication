using MediatR;
using UMS.Domain.Models;

namespace UMS.Application.Student.Command.EnrollStudent;

public class EnrollStudentCommand : IRequest<ClassEnrollment>
{
    public long CourseId { get; set; }
    public long StudentId { get; set; }
}