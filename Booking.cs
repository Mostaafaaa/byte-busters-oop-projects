using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Booking
    {


        public User Guest { get; set; }
        public Room Room { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public int GetTotalNights()
        {
            return (CheckOut - CheckIn).Days;
        }

        public int GetTotalPrice()
        {
            return Room.PricePerNight * GetTotalNights();
        }

        public void PrintBookingDetails()
        {
            Console.WriteLine("\n   "); //تم الحجز

            Console.WriteLine($"  {Guest.Name}");//الضيف
            Console.WriteLine($"  {Room.RoomNumber}, {Room.Type}");//الغرفة +نوعغرفه
            Console.WriteLine($" {GetTotalNights()},  {GetTotalPrice()}$");//عدد اللياتي+مبلغ كلي
            Console.WriteLine($"{CheckIn.ToShortDateString()} الى {CheckOut.ToShortDateString()}");
        }



         

    }
}
