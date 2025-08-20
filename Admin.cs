using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Admin : User
    {
      public void  ShowAllBookings(List<Booking> bookings)
        {
            Console.WriteLine("====Admin is viewing all Bookings ====");
            

            if (bookings.Count == 0)
            {
                Console.WriteLine("No bookings found!");
            }
            else
            {
                foreach (var booking in bookings)
                {
                    Console.WriteLine(
                        $"Guest: {booking.Guest.Name}, " +
                        $"Phone: {booking.Guest.Phone}, " +
                        $"Room: {booking.Room.RoomNumber}, " +
                        $"Check-In: {booking.CheckIn.ToShortDateString()}, " +
                        $"Check-Out: {booking.CheckOut.ToShortDateString()}"
                    );
                }
            }
        }

    }

}

