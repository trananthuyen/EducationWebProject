using System.ComponentModel.DataAnnotations;

namespace Entitites
{
    public class Course
    {
        [Key]
        public Guid? CourseID { get; set; }
        public string? CourseName { get; set; }

        public string? RateStarsCourse { get; set; }
        public string? RateComemtCourse { get; set; }

    }
}