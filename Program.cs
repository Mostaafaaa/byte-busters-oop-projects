using ConsoleApp3;
using HotelSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HotelSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                Hotel myHotel = new Hotel();
                Console.WriteLine($" Hotel Name: {myHotel.Name},  Phone: {myHotel.Phone}, Address: {myHotel.Address}");
                Console.WriteLine("Moring buffet availabel!");
                Console.WriteLine("=====================================");

                List<Room> rooms = new List<Room>();

                for (int i = 1; i <= 20; i++)
                {
                    string type = (i % 2 == 0) ? "VIP" : "standard";

                    switch (type)
                    {
                        case "VIP":
                            rooms.Add(new Room { RoomNumber = "Room-" + i, Type = "VIP", PricePerNight = 100 });
                            break;

                        case "standard":
                            rooms.Add(new Room { RoomNumber = "Room-" + i, Type = "standard", PricePerNight = 50 });
                            break;
                    }
                }

                // عرض الغرف
                Console.WriteLine("==== Available Rooms ====");
                foreach (var room in rooms)
                {
                    Console.WriteLine($"Number: {room.RoomNumber}, Type: {room.Type}, Price per night: {room.PricePerNight}$");
                }

                // لستة الحجوزات
                List<Booking> bookings = new List<Booking>();
                Reception reception = new Reception();

                string more = "y";
                while (more.ToLower() == "y")
                {
                    // بيانات الضيف
                    Console.WriteLine("\nInput name:");
                    User guest = new User { Name = Console.ReadLine() };

                    Console.WriteLine($"Choose a room number (ex Room-3):");
                    string selectedRoom = Console.ReadLine();

                    Console.WriteLine("Input phone (phone number):");
                    guest.Phone = Console.ReadLine();

                    Console.Write("Input check-in date (yyyy-mm-dd): ");
                    DateTime checkIn = DateTime.Parse(Console.ReadLine());

                    Console.Write("Input check-out date (yyyy-mm-dd): ");
                    DateTime checkOut = DateTime.Parse(Console.ReadLine());


                    // البحث عن الغرفة
                    Room bookedRoom = rooms.Find(r => r.RoomNumber == selectedRoom);

                    if (bookedRoom != null)
                    {
                        reception.MakeBooking(bookings, guest, bookedRoom, checkIn, checkOut);
                    }
                    else
                    {
                        Console.WriteLine("الغرفة غير موجودة!");
                    }

                    Console.Write("\nDo you want to add another booking? (y/n): ");
                    more = Console.ReadLine();

                }





                //الأدمن يعرض كل الحجوزات
                Admin admin = new Admin { Name = "System Admin" };
                admin.ShowAllBookings(bookings);

                 

               
               

            }
        }
    }



}
    


        


    

