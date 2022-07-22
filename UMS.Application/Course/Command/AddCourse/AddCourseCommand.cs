using System.ComponentModel.DataAnnotations;
using MediatR;
using NpgsqlTypes;
using UMS.Application.DTO;

namespace UMS.Application.Course.Command.AddCourse;

public class AddCourseCommand : IRequest<CourseDTO>
{
    [Required]
    public string Name { get; set; }
    public int MaxStudentsNumber { get; set; }
    public DateTime EnrolmentDateRangeL { get; set; }
    public DateTime EnrolmentDateRangeU { get; set; }
}