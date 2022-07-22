using MediatR;
using UMS.Domain.Models;
using UMS.Persistence;

namespace UMS.Application.Student.Querry.GetStudentsPerCourse;

public class GetStudentPerCourseQuerryHandler : IRequestHandler<GetStudentPerCourseQuerry, List<Domain.Models.User>>
{
    private readonly UmsContext _umsContext;


    public GetStudentPerCourseQuerryHandler(UmsContext umsContext)
    {
        _umsContext = umsContext;
    }

    public async Task<List<Domain.Models.User>> Handle(GetStudentPerCourseQuerry request,
        CancellationToken cancellationToken)
    {
        var data = _umsContext.ClassEnrollments
            .Join(
                _umsContext.TeacherPerCourses,
                classEnrollment => classEnrollment.ClassId,
                teacherPerCourse => teacherPerCourse.Id,
                (classEnrollment, teacherPerCourse) => new
                {
                    studentEnrolled = classEnrollment.StudentId,
                    courseId = teacherPerCourse.CourseId
                }
            ).ToList();

        List<long> studentIds = new List<long>();
        foreach (var variable in data)
        {
            if (variable.courseId == request.CourseId)
            {
                studentIds.Add(variable.studentEnrolled);
            }
        }

        var fullInfo = _umsContext.Users.Where(x => studentIds.Contains(x.Id)).ToList();
        return fullInfo;
    }
}