using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning_System
{
    internal class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; }



        public User()
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

        public virtual void GetUser(User user)
        {
            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"Name: {user.UserName}");
            Console.WriteLine($"Email: {user.Email}");
            Console.WriteLine($"First Name: {user.FirstName}");
            Console.WriteLine($"Last Name: {user.LastName}");
            Console.WriteLine($"Date of Birth: {user.DateOfBirth}");
            Console.WriteLine($"Registration Date: {user.RegistrationDate}");
        }
    }
}
