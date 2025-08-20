using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WareHouseMangementSystem
{
    internal class Clients
    {
        public String ID {  get; set; }
        public String Name { get; set; }

        public String Adress { get; set; }

        public String Number { get; set; }




        public Clients() 
        {


            this.ID = ID;
            this.Name = Name;
            this.Number = Number;
            this.Adress = Adress;

            try
            {
                Console.WriteLine("Before buying or selling you must enter the following information");
                Console.Write("Name: ");
                Name = Console.ReadLine();
                Console.Write("ID: ");
                ID = Console.ReadLine();
                Console.Write("Adress: ");
                Adress = Console.ReadLine();
                Console.Write("Number: ");
                Number = Console.ReadLine();

            }
            catch
            {
                Console.WriteLine("You entered something Wrong");
            }



        }
        public void AddOrder()
        {

        }
        public void EditOrder()
        {

        }
        public void DeleteOrder()
        {

        }

    }
}
