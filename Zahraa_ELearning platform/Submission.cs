using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning_System
{
    internal class Submission
    {
        public Student? Student { get; set; }
        public Assignment? Assignment { get; set; }
        public int Grade { get; set; } = 0; 
        public string Notes { get; set; } = string.Empty;

        // trying to add a studentId property to Submission class to fix the error in Helper.cs :((((
        public int studentId { get; set; }
        public List<Submission> Submissions { get; set; } = new List<Submission>();

        public void GradeSubmission(Student student, Assignment assignment, int grade)
        {
            if (student == null || assignment == null)
            {
                Console.WriteLine("Invalid student or assignment.");
                return;
            }
            if (grade < 0 || grade > 100)
            {
                Console.WriteLine("Grade must be between 0 and 100.");
                return;
            }
            
            if (Submissions.Any(s => s.Student == student && s.Assignment == assignment))
            {
                Console.WriteLine("This submission already exists.");
                return;
            }
            foreach (var submission in Submissions)
            {
                if (submission.Student == student && submission.Assignment == assignment)
                {
                    submission.Grade = grade;
                    submission.Notes = Notes;
                    Console.WriteLine($"The student {student.UserName} has been graded {grade} on the assignment {assignment.Title}.");
                    Submissions.Add(this);
                    
                }
            }
        }

        public void SubmitAssignment(Student student, Assignment assignment)
        {
            if (student == null || assignment == null)
            {
                Console.WriteLine("Invalid student or assignment.");
                return;
            }

            if (Submissions.Any(s => s.Student == student && s.Assignment == assignment))
            {
                Console.WriteLine("This submission already exists.");
                return;
            }

            var submission = new Submission
            {
                Student = student,
                Assignment = assignment,
                Notes = this.Notes,
                Grade = 0
            };

            Submissions.Add(submission);
            assignment.Submissions.Add(submission);
            Console.WriteLine($"The student {student.UserName} submitted the assignment {assignment.Title} successfully.");
        }

        public void ViewSubmissions(Student student, Assignment assignment)
        {
            var submissions = Submissions.Where(s => s.Student == student && s.Assignment == assignment);
            if (!submissions.Any())
            {
                Console.WriteLine("No submission found.");
                return;
            }
            foreach (var submission in submissions)
            {
                Console.WriteLine($"Student: {submission.Student.UserName}, Assignment: {submission.Assignment.Title}, Content: {submission.Notes}");
                if (Grade >= 90)
                {
                    Console.WriteLine("Excellent work!");
                }
                else if (Grade >= 75)
                {
                    Console.WriteLine("Good job!");
                }
                else if (Grade >= 50)
                {
                    Console.WriteLine("You passed.");
                }
                else
                {
                    Console.WriteLine("You need to improve.");
                }
            }
        }
        public void ViewStudentGrades(Student student)
        {
            var studentSubmissions = Submissions.Where(s => s.Student == student);
            if (!studentSubmissions.Any())
            {
                Console.WriteLine("No submissions found for this student.");
                return;
            }
            foreach (var submission in studentSubmissions)
            {
                Console.WriteLine($"Assignment: {submission.Assignment?.Title}, Grade: {submission.Grade}, Notes: {submission.Notes}");
            }
        }
    }
}
