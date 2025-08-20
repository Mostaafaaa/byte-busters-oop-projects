using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
      public class Reception:User
    {
         
    public void MakeBooking(List<Booking> bookings, User guest, Room room, DateTime checkIn, DateTime checkOut)
        {
            Booking booking = new Booking
            {
                Guest = guest,
                Room = room,
                CheckIn = checkIn,
                CheckOut = checkOut
            };

            bookings.Add(booking);
            Console.WriteLine( "    ");//تم حجز
    }
    }
}

