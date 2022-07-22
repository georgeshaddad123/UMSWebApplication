using NpgsqlTypes;

namespace UMS.Application.DTO;

public class CourseDTO
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int? MaxStudentsNumber { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}