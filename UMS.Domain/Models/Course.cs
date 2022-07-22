using System.ComponentModel.DataAnnotations;
using NpgsqlTypes;

namespace UMS.Domain.Models
{
    public partial class Course
    {
        public Course()
        {
            TeacherPerCourses = new HashSet<TeacherPerCourse>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        [Required]
        [MinLength(5,ErrorMessage = "We need at least 5 students to open this course.")]
        [MaxLength(12, ErrorMessage = "Maximum capacity for this course is 12.")]
        public int? MaxStudentsNumber { get; set; }
        public NpgsqlRange<DateOnly>? EnrolmentDateRange { get; set; }

        public virtual ICollection<TeacherPerCourse> TeacherPerCourses { get; set; }
    }
}
