using MediatR;

namespace UMS.Application.Student.Querry.GetStudentsPerCourse;

public class GetStudentPerCourseQuerry : IRequest<List<Domain.Models.User>>
{
    public int CourseId { get; set; }
}