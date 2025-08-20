using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace WareHouseMangementSystem
{
    internal class Staff
    {

        public String StaffName { get; set; }
        public String StaffID { get; set; }

        public Staff(string staffName, string staffID)
        {
            StaffName = staffName;
            StaffID = staffID;
            String Task;
            while (true) 
            {
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine($"  hi Staff {this.StaffName} ID: {this.StaffID}");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.Write("you have nothing to do wait for the manger to give you tasks...");
                Task = Console.ReadLine();

               


            }
        }
    }
}
