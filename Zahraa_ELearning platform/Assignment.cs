using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning_System
{
    internal class Assignment: Course
    {
        // public string Title { get; set; } = string.Empty;
        // public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public int assignmentId { get; set; }
        // Add this property to the Assignment class
        public List<Submission> Submissions { get; set; } = new List<Submission>();
        public void Display()
        {
            Console.WriteLine($"Assignment: {Title}\nDue: {DueDate}\n{Description}");
        }

        public void AddAssignment()
        {
            Console.WriteLine("Please enter assignment details:");
            Console.Write("Title: ");
            Title = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateInput(Title);
            Console.Write("Description: ");
            Description = Console.ReadLine() ?? string.Empty;
            Helpers.ValidateInput(Description);
            Console.Write("Due Date (yyyy-mm-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
            {
                DueDate = dueDate;
                Console.WriteLine($"Assignment: {Title}\nDue: {DueDate}\n{Description}");
            }
            else
            {
                Console.WriteLine("Invalid date format. Please try again.");
                AddAssignment(); // Retry input
            }
        }

    }       
}
