using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace E_Learning_System
{
    internal class SystemManager : User
    {
        public List<User> Users { get; set; } = new(); // initialize the list
        public List<Course> Courses { get; set; } = new();

        

        public void ListAllCourses()
        {
            if (!Courses.Any())
            {
                Console.WriteLine("No courses available in the system.");
                return;
            }
            
            Console.WriteLine("\n=== All Available Courses ===");
            foreach (Course course in Courses)
            {
                Console.WriteLine($"\n--------------------------------\n" +
                    $"Course ID: {course.CourseId}");
                Console.WriteLine($"Title: {course.Title}");
                Console.WriteLine($"Description: {course.Description}");
                Console.WriteLine($"Instructor: {course.Instructor?.UserName ?? "N/A"}" +
                                   $"\n--------------------------------\n");
            }
        }

        public void ListAllUsers()
        {
            if (!Users.Any())
            {
                Console.WriteLine("No users registered in the system.");
                return;
            }
            
            Console.WriteLine("\n=== All Registered Users ===");
            foreach (var user in Users)
            {
                string userType = user.GetType().Name;
                Console.WriteLine($"ID: {user.Id}, Name: {user.UserName}, Email: {user.Email}, Type: {userType}");
            }
        }

        public void ListAllStudents()
        {
            var students = Users.OfType<Student>().ToList();
            if (!students.Any())
            {
                Console.WriteLine("No students registered in the system.");
                return;
            }
            
            Console.WriteLine("\n=== All Registered Students ===");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.UserName}, Email: {student.Email}");
            }
        }

        public void GetUserDetails(int userId)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.GetUser(user);
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        public void GetCourseDetails(int courseId)
        {
            var course = Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (course != null)
            {
                Console.WriteLine($"Course ID: {course.CourseId}");
                Console.WriteLine($"Title: {course.Title}");
                Console.WriteLine($"Description: {course.Description}");
                Console.WriteLine($"Instructor: {course.Instructor?.UserName ?? "N/A"}");
                Console.WriteLine("Enrolled Students:");
                foreach (var student in course.EnrolledStudents)
                {
                    Console.WriteLine($"- {student.UserName}");
                }
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        public void EnrollUserInCourse(int userId, int courseId)
        {
            // First, check if any users exist
            if (!Users.Any())
            {
                Console.WriteLine("No users registered in the system. Please register users first.");
                return;
            }

            // Check if any students exist
            var allStudents = Users.OfType<Student>().ToList();
            if (!allStudents.Any())
            {
                Console.WriteLine("No students registered in the system. Please register students first.");
                Console.WriteLine("Available users:");
                foreach (var user in Users)
                {
                    Console.WriteLine($"- ID: {user.Id}, Name: {user.UserName}, Type: {user.GetType().Name}");
                }
                return;
            }

            Student student = allStudents.FirstOrDefault(u => u.Id == userId);
            if (student == null)
            {
                Console.WriteLine($"User with ID {userId} is not a student or does not exist.");
                Console.WriteLine("Available students:");
                foreach (var s in allStudents)
                {
                    Console.WriteLine($"- ID: {s.Id}, Name: {s.UserName}");
                }
                return;
            }

            // Check if any courses exist
            if (!Courses.Any())
            {
                Console.WriteLine("No courses available in the system. Please add courses first.");
                return;
            }

            var course = Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (course == null)
            {
                Console.WriteLine($"Course with ID {courseId} not found.");
                Console.WriteLine("Available courses:");
                foreach (var c in Courses)
                {
                    Console.WriteLine($"- ID: {c.CourseId}, Title: {c.Title}");
                }
                return;
            }

            if (course.EnrolledStudents.Any(s => s.Id == userId))
            {
                Console.WriteLine($"User {student.UserName} is already enrolled in course {course.Title}.");
                return;
            }

            student.Enroll(course);
            Console.WriteLine($"User {student.UserName} enrolled in course {course.Title} successfully!");
        }

        public void AddCourse(Course course)
        {
            Console.WriteLine("Please enter course details:");
            Console.Write("Course ID: ");
            course.CourseId = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Title: ");
            course.Title = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateInput(course.Title);

            Console.Write("Description: ");
            course.Description = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateInput(course.Description);

            Console.Write("Instructor Name: ");
            course.Instructor = new Instructor { UserName = Console.ReadLine() ?? string.Empty };
            Helpers.ValidateInput(course.Instructor.UserName);

            Courses.Add(course);
            Console.WriteLine("Course added successfully!");
        }

        public void ShowEnrollmentHelp()
        {
            Console.WriteLine("\n=== Enrollment Help ===");
            Console.WriteLine("To enroll a student in a course, you need:");
            Console.WriteLine("1. At least one registered student");
            Console.WriteLine("2. At least one available course");
            Console.WriteLine("3. The correct Student ID and Course ID");
            
            Console.WriteLine("\nCurrent Status:");
            Console.WriteLine($"- Registered Students: {Users.OfType<Student>().Count()}");
            Console.WriteLine($"- Available Courses: {Courses.Count}");
            
            if (Users.OfType<Student>().Any())
            {
                Console.WriteLine("\nAvailable Students:");
                ListAllStudents();
            }
            
            if (Courses.Any())
            {
                Console.WriteLine("\nAvailable Courses:");
                ListAllCourses();
            }
        }

    }

}
