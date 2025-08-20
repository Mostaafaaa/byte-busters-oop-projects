using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseMangementSystem
{
    internal class Suppliers:Clients
    {
        //  adding storage object to 
        Storge storge = new Storge();
        public Suppliers() 
        {
            Console.WriteLine(Name);
            Console.WriteLine(ID);
            Console.WriteLine(Adress);
            Console.WriteLine(Number);
            Sell();
        }
        public void Sell()
        {
            try
            {

                Console.WriteLine("Enter product details:");
                Console.Write("Name: ");
                String Name = Console.ReadLine();
                Console.Write("Price: ");
                double Price = Convert.ToDouble(Console.ReadLine());
                Console.Write("Code: ");
                String Code = Console.ReadLine();
                Console.Write("ValumePerUnit: ");
                double ValumePerUnit = Convert.ToDouble(Console.ReadLine());
                Console.Write("and finaly how much can u sell me(amount): ");
                int Count = Convert.ToInt32(Console.ReadLine());
                //  supplier name is already give no need to reEnter
                String Supplier = Name;

                storge.GoodsInsertingSystem(new Good(Name, Price, Code, ValumePerUnit, Supplier, Count));



            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("You enter something wronge with the product details");
            }

            



        }
    }
}
