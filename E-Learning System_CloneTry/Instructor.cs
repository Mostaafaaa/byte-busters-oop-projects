using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning_System
{
    internal class Instructor: User
    {
        public Instructor()
        {
            Id = 0;
            UserName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = string.Empty;
            RegistrationDate = DateTime.Now;
        }
        public List<Course> TeachingCourses { get; set; } = new();

        public void AddCourse(Course course)
        {
            Console.WriteLine("Please enter course details:");
            Console.Write("Course ID: ");
            course.CourseId = int.Parse(Console.ReadLine());

            Console.Write("Title: ");
            course.Title = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateInput(course.Title);

            Console.Write("Description: ");
            course.Description = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateInput(course.Description);

            // Assign the current instructor as the course instructor
            course.Instructor = this;
            Console.WriteLine("Course added successfully!");

            TeachingCourses.Add(course);
        }
    }
}
