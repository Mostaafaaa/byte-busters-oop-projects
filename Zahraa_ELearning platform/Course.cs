using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning_System
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Instructor? Instructor { get; set; }
        public List<Student> EnrolledStudents { get; set; } = new();
        public List<string> Materials { get; set; } = new();
        public List<Assignment> Assignments { get; set; } = new();
        public List<Quiz> Quizzes { get; set; } = new();

        public void AddMaterial(string material) => Materials.Add(material);
        public void AddAssignment(Assignment assignment) => Assignments.Add(assignment);
        public void AddQuiz(Quiz quiz) => Quizzes.Add(quiz);
    }
}
