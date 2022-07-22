namespace UMS.Domain.Models
{
    public partial class User
    {
        public User()
        {
            ClassEnrollments = new HashSet<ClassEnrollment>();
            TeacherPerCourses = new HashSet<TeacherPerCourse>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long RoleId { get; set; }
        public string KeycloakId { get; set; }
        public string Email { get; set; }
        public bool? Subscribe { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<ClassEnrollment> ClassEnrollments { get; set; }
        public virtual ICollection<TeacherPerCourse> TeacherPerCourses { get; set; }
    }
}
