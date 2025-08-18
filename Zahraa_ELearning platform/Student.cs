using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace E_Learning_System
{
    internal class Student: User
    {
        public string StudentLevel { get; set; } = string.Empty;
        public List<Course> EnrolledCourses { get; set; } = new();
        public int studentId { get; set; }

        public void Enroll(Course course)
        {
            EnrolledCourses.Add(course);
            course.EnrolledStudents.Add(this);
            Console.WriteLine($"{UserName} enrolled in {course.Title}");
        }
    }
}
