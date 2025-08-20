using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning_System
{
    internal class Quiz
    {
        public string Title { get; set; } = string.Empty;
        public struct Qustion
        {
            public string Text;
            public List<string> Options;
            public string CorrectAnswer;
        }
        public List<Qustion> Questions { get; set; } = new();
        public string Answer { get; set; } = string.Empty;

        public int score { get; set; } = 0;
        public void StatisticsQuiz()
        {
            // semulating a multiple choice quiz in statistics for CS students
            
            Console.WriteLine($"1. Which of the following is a measure of central tendency?\nA) Variance\nB) Standard deviation\nC) Mean\nD) Range");
            Console.WriteLine("Your answer: ");
            Answer = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateInput(Answer);
            if (Answer.ToUpper() == "C")
            {
                score += 20;
            }
            Console.WriteLine($"2. In a dataset of students' exam scores, the standard deviation is small. What does this indicate?\nA) Scores are widely spread out.\nB) Scores are closely clustered around the mean.\nC) The dataset has a high mean.\nD) There are many outliers.");
            Console.WriteLine("Your answer: ");
            Answer = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateInput(Answer);
            if (Answer.ToUpper() == "B")
            {
                score += 20;
            }
            Console.WriteLine($"3. Which of the following is a measure of dispersion?\nA) Mean\nB) Standard deviation\nC) Range\nD) Variance");
            Console.WriteLine("Your answer: ");
            Answer = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateInput(Answer);
            if (Answer.ToUpper() == "B")
            {
                score += 20;
            }
            Console.WriteLine($"4. In a dataset of students' exam scores, the range is large. What does this indicate?\nA) Scores are widely spread out.\nB) Scores are closely clustered around the mean.\nC) The dataset has a high mean.\nD) There are many outliers.");
            Console.WriteLine("Your answer: ");
            Answer = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateInput(Answer);
            if (Answer.ToUpper() == "A")
            {
                score += 20;
            }
            Console.WriteLine($"5. Which of the following is a measure of central tendency?\nA) Variance\nB) Standard deviation\nC) Mean\nD) Range");
            Console.WriteLine("Your answer: ");
            Answer = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateInput(Answer);
            if (Answer.ToUpper() == "C")
            {
                score += 20;
            }
            Console.WriteLine($"Your score is: {score}/100");
            Console.WriteLine("Thank you for taking the quiz!");
        }
        public void DataStructuresQuiz()
        {
            List<string> questions = new List<string>
            {
                "1. What is the time complexity of accessing an element in an array?",
                "2. What is the primary difference between a stack and a queue?",
                "3. Which data structure uses LIFO (Last In, First Out) principle?",
                "4. What is the time complexity of searching for an element in a balanced binary search tree?",
                "5. What is the main advantage of using a hash table?"
            };
            List<string> options = new List<string>
            {
                "A) O(1)\nB) O(n)\nC) O(log n)\nD) O(n^2)",
                "A) Stack allows insertion at both ends, while queue allows insertion at one end and deletion at the other.\nB) Stack allows insertion and deletion at both ends, while queue allows insertion at one end and deletion at the other.\nC) Stack allows insertion and deletion at one end, while queue allows insertion at one end and deletion at the other.\nD) Stack allows insertion and deletion at both ends, while queue allows insertion and deletion at one end.",
                "A) Stack\nB) Queue\nC) Linked List\nD) Array",
                "A) O(1)\nB) O(n)\nC) O(log n)\nD) O(n^2)",
                "A) It uses less memory than other data structures.\nB) It allows for fast access to elements by their keys.\nC) It is easier to implement than other data structures.\nD) It is more efficient for searching than other data structures."
            };
            List<string> answers = new List<string>
            {
                "A", // O(1)
                "C", // Stack allows insertion and deletion at one end, while queue allows insertion at one end and deletion at the other.
                "A", // Stack
                "C", // O(log n)
                "B"  // It allows for fast access to elements by their keys.
            };
            int score = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine(questions[i]);
                Console.WriteLine(options[i]);
                Console.Write("Your answer: ");
                Answer = Console.ReadLine()?.ToUpper() ?? string.Empty;
                Helpers.ValidateInput(Answer);
                if (Answer == answers[i])
                {
                    score += 20;
                }
            }
            Console.WriteLine($"Your score is: {score}/100");
            Console.WriteLine("Thank you for taking the quiz!");

        }

        public void AddQuiz(string title, List<string> questions, string answer)
        {
            Title = title;
            Questions = questions.Select(q => new Qustion { CorrectAnswer = answer }).ToList();
            Console.WriteLine($"Quiz '{Title}' has been added with {Questions.Count} questions.");
        }

    }
}
