using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static E_Learning_System.Quiz;

namespace E_Learning_System
{
    internal class Helpers:SystemManager
    {
        private static SystemManager _systemManager = new SystemManager();
        public static void DisplayWelcome()
        {
            Console.WriteLine("Please enter the System Manager password:");
            string password = Console.ReadLine() ?? string.Empty;
            if (password == "123456")
            {
                DisplayMainMenu();
                //Console.WriteLine("Welcome to the E-Learning System!");
                //Console.WriteLine("Please select an option:");
                //Console.WriteLine("1. Display Main Menu");
                //Console.WriteLine("2. List all users (Needs a Database)");
                //Console.WriteLine("3. List all courses (Needs a Database)");
                //Console.WriteLine("4. Get user details (Needs a Database)");
                //Console.WriteLine("5. Get course details (Needs a Database)");
                //Console.WriteLine("6. Exit System");
                //Console.Write("Your choice: ");
                //string input = Console.ReadLine();
                //if (int.TryParse(input, out int choice))
                //{
                //    switch (choice)
                //    {
                //        case 1:
                //            DisplayMainMenu();
                //            break;
                //        case 2:
                //            _systemManager.ListAllUsers(); // _ means that we are using the instance of the SystemManager class  
                //            break;
                //        case 3:
                //            _systemManager.ListAllCourses();
                //            break;
                //        case 4:
                //            Console.Write("Enter user ID: ");
                //            string UserIdInput = Console.ReadLine();
                //            ValidateInput(UserIdInput);
                //            if (int.TryParse(UserIdInput, out int userId))
                //            {
                //                _systemManager.GetUserDetails(userId);
                //            }
                //            else
                //            {
                //                Console.WriteLine("Invalid user ID.");
                //            }
                //            break;
                //        case 5:
                //            Console.Write("Enter course ID: ");
                //            string CourseIdInput = Console.ReadLine();
                //            ValidateInput(CourseIdInput);
                //            if (int.TryParse(CourseIdInput, out int courseId))
                //            {
                //                _systemManager.GetCourseDetails(courseId);
                //            }
                //            else
                //            {
                //                Console.WriteLine("Invalid course ID.");
                //            }
                //            break;
                //        case 6:
                //            Console.WriteLine("Thank you for using the E-Learning System. Goodbye!");
                //            break;
                //        default:
                //            Console.WriteLine("Invalid choice. Please try again.");
                //            break;
                //    }
                //}

            }
        }

        public static void DisplayMainMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== E-Learning System ===");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Your choice: ");
                
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            HandleLogin();
                            break;
                        case 2:
                            HandleRegistration();
                            break;
                        case 3:
                            Console.WriteLine("Thank you for using the E-Learning System. Goodbye!");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        private static void HandleLogin()
        {
            Console.Write("Please enter your Email: ");
            string email = Console.ReadLine() ?? string.Empty;
            Console.Write("Please enter your Password: ");
            string password = Console.ReadLine() ?? string.Empty;

            var user = _systemManager.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                Console.WriteLine($"Welcome back, {user.UserName}!");
                // Direct user to appropriate menu based on their type
                if (user is Student)
                {
                    DisplayStudentMenu();
                }
                else if (user is Instructor)
                {
                    DisplayInstructorMenu();
                }
                else
                {
                    Console.WriteLine("Access denied. Contact administrator.");
                }
            }
            else
            {
                Console.WriteLine("Invalid email or password. Please try again.");
            }
        }

        private static void HandleRegistration()
        {
            Console.WriteLine("\n=== User Registration ===");
            Console.Write("Please enter your Name: ");
            string name = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Please enter your Email: ");
            string regEmail = Console.ReadLine() ?? string.Empty;
            Match match = Regex.Match(regEmail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            // Validate email using regex
            if (!match.Success)
            {
                Console.WriteLine("Invalid email format. Please enter a valid email address.");
                return;
            }

            
            Console.Write("Please enter your Password: ");
            string regPassword = Console.ReadLine() ?? string.Empty;
            
            Console.Write("Please enter your Role (Student/Instructor): ");
            string role = Console.ReadLine() ?? string.Empty;

            User newUser = null;
            if (role.Equals("Student", StringComparison.OrdinalIgnoreCase))
            {
                newUser = new Student 
                { 
                    Id = _systemManager.Users.Count + 1,
                    UserName = name, 
                    Email = regEmail, 
                    Password = regPassword,
                    RegistrationDate = DateTime.Now
                };
            }
            else if (role.Equals("Instructor", StringComparison.OrdinalIgnoreCase))
            {
                newUser = new Instructor 
                { 
                    Id = _systemManager.Users.Count + 1,
                    UserName = name, 
                    Email = regEmail, 
                    Password = regPassword,
                    RegistrationDate = DateTime.Now
                };
            }
            else
            {
                Console.WriteLine("Invalid role. Please try again.");
                return;
            }

            // Check if email already exists
            if (_systemManager.Users.Any(u => u.Email == regEmail))
            {
                Console.WriteLine("Email already exists. Please use a different email.");
                return;
            }

            _systemManager.Users.Add(newUser);
            Console.WriteLine($"{role} {newUser.UserName} registered successfully! Your ID is: {newUser.Id}");
        }

        public static void ValidateInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentNullException(nameof(input));
        }
        public static void DisplayInstructorMenu()
        {
            Console.WriteLine("\n=== Instructor Portal ===");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. Create New Course");
                Console.WriteLine("2. View My Courses");
                Console.WriteLine("3. Add Course Material");
                Console.WriteLine("4. Create Assignment");
                Console.WriteLine("5. Create Quiz");
                Console.WriteLine("6. Grade Submissions");
                Console.WriteLine("7. View Course Students");
                Console.WriteLine("8. Back to Main Menu");
                Console.Write("\nYour choice: ");

                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter your Instructor ID: ");
                            if (int.TryParse(Console.ReadLine(), out int instructorId))
                            {
                                var instructor = _systemManager.Users.OfType<Instructor>().FirstOrDefault(i => i.Id == instructorId);
                                if (instructor != null)
                                {
                                    var newCourse = new Course();
                                    instructor.AddCourse(newCourse);
                                    _systemManager.Courses.Add(newCourse);
                                }
                                else
                                {
                                    Console.WriteLine("Instructor not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Instructor ID.");
                            }
                            break;
                        case 2:
                            Console.Write("Enter your Instructor ID: ");
                            if (int.TryParse(Console.ReadLine(), out int viewInstructorId))
                            {
                                var instructor = _systemManager.Users.OfType<Instructor>().FirstOrDefault(i => i.Id == viewInstructorId);
                                if (instructor != null)
                                {
                                    Console.WriteLine("\n=== My Teaching Courses ===");
                                    if (instructor.TeachingCourses.Any())
                                    {
                                        foreach (var course in instructor.TeachingCourses)
                                        {
                                            Console.WriteLine($"- {course.Title} (ID: {course.CourseId})");
                                            Console.WriteLine($"  Students enrolled: {course.EnrolledStudents.Count}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You are not teaching any courses yet.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Instructor not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Instructor ID.");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Please enter Course ID: ");
                            int CId;
                            if (int.TryParse(Console.ReadLine(), out CId))
                            {
                                var course = _systemManager.Courses.FirstOrDefault(c => c.CourseId == CId);
                                if (course != null)
                                {
                                    Console.WriteLine("Enter the Reference Book as follows: Book title - Publishing year.");
                                    //Console.WriteLine("example: ");
                                    //Console.WriteLine("Introduction to Algorithms - 2009");
                                    //Match match = Regex.Match(Console.ReadLine() ?? string.Empty, @"^.+ - \d{4}$");

                                    //if (!match.Success)
                                    //{
                                    //    Console.WriteLine("Invalid format. Please use 'Book title - Publishing year'.");
                                    //    return;
                                    //}
                                    string material = Console.ReadLine() ?? string.Empty;
                                    Helpers.ValidateInput(material);
                                    course.AddMaterial(material);
                                    Console.WriteLine("Material added successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Course not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Course ID.");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Please enter the course ID: ");
                            if (int.TryParse(Console.ReadLine(), out int crsId))
                            {
                                var course = _systemManager.Courses.FirstOrDefault(c => c.CourseId == crsId);
                                if (course != null)
                                {
                                    var assignment = new Assignment();
                                    assignment.AddAssignment();
                                    course.AddAssignment(assignment);
                                    Console.WriteLine("Assignment created successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("Course not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Course ID.");
                            }
                            break;
                        case 5:
                            Console.WriteLine("Enter Course ID: ");
                            if (int.TryParse(Console.ReadLine(), out int quizCourseId))
                            {
                                var course = _systemManager.Courses.FirstOrDefault(c => c.CourseId == quizCourseId);
                                if (course != null)
                                {
                                    var quiz = new Quiz();
                                    Console.WriteLine("Please enter the quiz title: ");
                                    string title = Console.ReadLine() ?? string.Empty;
                                    List<Qustion> questions = new List<Qustion>();

                                    Console.WriteLine("Please enter the number of questions: ");
                                    if (int.TryParse(Console.ReadLine(), out int numQuestions) && numQuestions > 0)
                                    {
                                        //for (int i = 0; i < numQuestions; i++)
                                        //{
                                        //    Console.Write($"Enter question {i + 1}: ");
                                        //    string QuestionText = Console.ReadLine() ?? string.Empty;
                                        //    Helpers.ValidateInput(QuestionText);

                                        for (int i = 0; i < numQuestions; i++)
                                        {
                                            Console.Write($"Enter question {i + 1}: ");
                                            string QuestionText = Console.ReadLine() ?? string.Empty;
                                            Helpers.ValidateInput(QuestionText);

                                            var question = new Qustion
                                            {
                                                Text = QuestionText,
                                                Options = new List<string>()
                                            };

                                            for (int j = 0; j < 4; j++)
                                            {
                                                Console.Write($"Enter option {(char)('A' + j)} for question {i + 1}: ");
                                                string option = Console.ReadLine() ?? string.Empty;
                                                Helpers.ValidateInput(option);
                                                question.Options.Add(option);
                                            }

                                            Console.Write($"Enter answer for question {i + 1}: ");
                                            string Answer = Console.ReadLine() ?? string.Empty;
                                            Helpers.ValidateInput(Answer);
                                            question.CorrectAnswer = Answer;

                                            questions.Add(question);
                                        }
                                    }
                                    var Course = _systemManager.Courses.FirstOrDefault(c => c.CourseId == quizCourseId);
                                    if (Course != null)
                                    {
                                        quiz.Title = title;
                                        quiz.Questions = questions;
                                        Course.AddQuiz(quiz);
                                        Console.WriteLine("Quiz created successfully!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Course not found.");
                                    }
                                }
                            }
                            break;
                        case 6:
                            Console.Write("Enter Course ID to grade submissions: ");
                            if (int.TryParse(Console.ReadLine(), out int courseId))
                            {
                                var course = _systemManager.Courses.FirstOrDefault(c => c.CourseId == courseId);
                                if (course != null)
                                {
                                    Console.Write("Enter Assignment ID to grade submissions: ");
                                    if (int.TryParse(Console.ReadLine(), out int assignmentId))
                                    {
                                        var assignment = course.Assignments.FirstOrDefault(a => a.assignmentId == assignmentId);
                                        if (assignment != null)
                                        {
                                            Console.Write("Enter Student ID to grade submissions: ");
                                            if (int.TryParse(Console.ReadLine(), out int studentId))
                                            {
                                                var student = _systemManager.Users.OfType<Student>().FirstOrDefault(s => s.Id == studentId);
                                                var submission = assignment.Submissions.FirstOrDefault(s => s.Student?.Id == studentId);

                                                if (submission != null)
                                                {
                                                    Console.Write("Enter grade (0-100): ");
                                                    if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 0 && grade <= 100)
                                                    {
                                                        Console.Write("Enter notes for the submission: ");
                                                        string notes = Console.ReadLine() ?? string.Empty;
                                                        Helpers.ValidateInput(notes);

                                                        submission.Grade = grade;
                                                        submission.Notes = notes;
                                                        Console.WriteLine($"Graded {student.UserName} with {grade} on {assignment.Title}.");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid grade. Please enter a number between 0 and 100.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("No submission found for this student.");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        case 7:
                            Console.Write("Enter Course ID to view students: ");
                            if (int.TryParse(Console.ReadLine(), out int CrsId))
                            {
                                var course = _systemManager.Courses.FirstOrDefault(c => c.CourseId == CrsId);
                                if (course != null)
                                {
                                    Console.WriteLine($"\n=== Students in {course.Title} ===");
                                    if (course.EnrolledStudents.Any())
                                    {
                                        foreach (var student in course.EnrolledStudents)
                                        {
                                            Console.WriteLine($"- {student.UserName} (ID: {student.Id})");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No students enrolled in this course yet.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Course not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Course ID.");
                            }
                            break;
                        case 8:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        public static void DisplayStudentMenu()
        {
            Console.WriteLine("\n=== Student Portal ===");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nPlease select an option:");
                Console.WriteLine("1. View Available Courses");
                Console.WriteLine("2. View My Enrolled Courses");
                Console.WriteLine("3. Enroll in a Course");
                Console.WriteLine("4. View Course Materials");
                Console.WriteLine("5. Submit Assignment");
                Console.WriteLine("6. Take Quiz");
                Console.WriteLine("7. View My Grades");
                Console.WriteLine("8. Back to Main Menu");
                Console.Write("\nYour choice: ");

                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            _systemManager.ListAllCourses();
                            break;
                        case 2:
                            Console.Write("Enter your Student ID: ");
                            if (int.TryParse(Console.ReadLine(), out int studentId))
                            {
                                var student = _systemManager.Users.OfType<Student>().FirstOrDefault(s => s.Id == studentId);
                                if (student != null)
                                {
                                    Console.WriteLine("\n=== My Enrolled Courses ===");
                                    if (student.EnrolledCourses.Any())
                                    {
                                        foreach (var course in student.EnrolledCourses)
                                        {
                                            Console.WriteLine($"- {course.Title} (ID: {course.CourseId})");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You are not enrolled in any courses yet.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Student not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Student ID.");
                            }
                            break;
                        case 3:
                            Console.Write("Enter your Student ID: ");
                            if (int.TryParse(Console.ReadLine(), out int enrollStudentId))
                            {
                                Console.Write("Enter Course ID to enroll: ");
                                if (int.TryParse(Console.ReadLine(), out int courseId))
                                {
                                    _systemManager.EnrollUserInCourse(enrollStudentId, courseId);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Course ID.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Student ID.");
                            }
                            break;
                        case 4:
                            Console.Write("Enter Course ID to view materials: ");
                            if (int.TryParse(Console.ReadLine(), out int materialCourseId))
                            {
                                var course = _systemManager.Courses.FirstOrDefault(c => c.CourseId == materialCourseId);
                                if (course != null)
                                {
                                    Console.WriteLine($"\n=== Course Materials for {course.Title} ===");
                                    if (course.Materials.Any())
                                    {
                                        foreach (var material in course.Materials)
                                        {
                                            Console.WriteLine($"{material}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No materials available for this course yet.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Course not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Course ID.");
                            }
                            break;
                        case 5:
                            Submission submission = new Submission();
                            Console.Write("Enter Course ID to submit assignment: ");
                            if (int.TryParse(Console.ReadLine(), out int assignmentCourseId))
                            {
                                Console.Write("Enter Assignment ID to submit: ");
                                if (int.TryParse(Console.ReadLine(), out int assignmentId))
                                {
                                    Console.Write("Enter your Student ID: ");
                                    if (int.TryParse(Console.ReadLine(), out int studentIdForSubmission))
                                    {
                                        var course = _systemManager.Courses.FirstOrDefault(c => c.CourseId == assignmentCourseId);
                                        var student = _systemManager.Users.OfType<Student>().FirstOrDefault(s => s.Id == studentIdForSubmission);
                                        if (course != null && student != null)
                                        {
                                            submission.SubmitAssignment(student, course.Assignments.FirstOrDefault(a => a.CourseId == assignmentId));
                                            Console.WriteLine("Assignment submitted successfully!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Course ID or Student ID.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Student ID.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Assignment ID.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Course ID.");
                            }
                            break;
                        case 6:
                            Quiz quiz = new Quiz();
                            Console.WriteLine("Please enter your Student ID: ");
                            if (int.TryParse(Console.ReadLine(), out int studentIdForQuiz))
                            {
                                var student = _systemManager.Users.OfType<Student>().FirstOrDefault(s => s.Id == studentIdForQuiz);
                                if (student != null)
                                {
                                    Console.WriteLine("\n=== Available Quizzes ===");
                                    foreach (var course in _systemManager.Courses)
                                    {
                                        if (course.Quizzes.Any())
                                        {
                                            Console.WriteLine($"Course: {course.Title}");
                                            foreach (var q in course.Quizzes)
                                            {
                                                Console.WriteLine($"- {q.Title}");
                                            }
                                        }
                                    }
                                    Console.Write("Enter the title of the quiz you want to take: ");
                                    string quizTitle = Console.ReadLine() ?? string.Empty;
                                    var selectedQuiz = _systemManager.Courses
                                        .SelectMany(c => c.Quizzes)
                                        .FirstOrDefault(q => q.Title.Equals(quizTitle, StringComparison.OrdinalIgnoreCase));
                                    if (selectedQuiz != null)
                                        {
                                        Console.WriteLine($"Starting quiz: {selectedQuiz.Title}");
                                        foreach (var question in selectedQuiz.Questions)
                                        {
                                            Console.WriteLine(question.Text);
                                            for (int i = 0; i < question.Options.Count; i++)
                                            {
                                                Console.WriteLine($"{(char)('A' + i)}. {question.Options[i]}");
                                            }
                                            Console.Write("Your answer: ");
                                            string answer = Console.ReadLine() ?? string.Empty;
                                            if (answer.Equals(question.CorrectAnswer, StringComparison.OrdinalIgnoreCase))
                                            {
                                                //selectedQuiz.DataStructuresQuiz();
                                                selectedQuiz.score += 20; // each correct answer gives 20 points
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Incorrect. The correct answer is: {question.CorrectAnswer}");
                                            }
                                        }
                                        // the score is calculated based on the number of correct answers/ number of questions
                                        Console.WriteLine($"Quiz completed!\nYou scored {selectedQuiz.score}/ {selectedQuiz.Questions.Count * 20}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Quiz not found.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Student not found.");
                                }
                            }
                            //Console.WriteLine("I want to take a Quiz in (1- Statistics or 2- Data Structures): ");
                            //if (int.TryParse(Console.ReadLine(), out int quizChoice))
                            //{
                            //    switch (quizChoice)
                            //    {
                            //        case 1: 
                            //            quiz.StatisticsQuiz();
                            //            break;
                            //        case 2:
                            //            quiz.DataStructuresQuiz();
                            //            break;
                            //        default:
                            //            Console.WriteLine("Invalid choice.");
                            //            break;
                            //    }
                            //}
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            break;
                        case 7:
                            Submission submission1 = new Submission();
                            Console.Write("Enter your Student ID to view grades: ");
                            if (int.TryParse(Console.ReadLine(), out int studentIdForGrades))
                            {
                                var student = _systemManager.Users.OfType<Student>().FirstOrDefault(s => s.Id == studentIdForGrades);
                                if (student != null)
                                {
                                    Console.WriteLine($"\n=== Grade Report for {student.UserName} ===");
                                    var enrolledCourses = student.EnrolledCourses;
                                    if (enrolledCourses.Any())
                                    {
                                        foreach (var course in enrolledCourses)
                                        {
                                            Console.WriteLine($"\nCourse: {course.Title}");
                                            if (course.Assignments.Any())
                                            {
                                                Console.WriteLine("Assignments:");
                                                foreach (var assignment in course.Assignments)
                                                {
                                                    var submissionn = assignment.Submissions?.FirstOrDefault(s => s.Student?.Id == student.Id);
                                                    if (submissionn != null)
                                                    {
                                                        Console.WriteLine($"- {assignment.Title}: {submissionn.Grade}/100");
                                                        if (!string.IsNullOrEmpty(submissionn.Notes))
                                                        {
                                                            Console.WriteLine($"  Instructor Notes: {submissionn.Notes}");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine($"- {assignment.Title}: Not submitted");
                                                    }
                                                }
                                            }
                                            
                                            if (course.Quizzes.Any())
                                            {
                                                Console.WriteLine("\nQuizzes:");
                                                foreach (var quizz in course.Quizzes)
                                                {
                                                    Console.WriteLine($"- {quizz.Title}: {quizz.score}/100");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("You are not enrolled in any courses.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Student not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Student ID.");
                            }
                            break;
                        case 8:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }


    }
}
