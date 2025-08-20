using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace HotelSystem
{
    public class Hotel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool HasMorningBuffet {  get; set; }


        public Hotel()
        {
            Console.WriteLine("New Hotel created");

            Name = " Baghdad Hotel" ;
            Address = " Bagdad";
            Phone = "077889999";
            HasMorningBuffet = true;





    }

        
}
}

