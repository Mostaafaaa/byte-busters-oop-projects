using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseMangementSystem
{
    public class Good
    {
        public String Name {  get; set; }
        public double Price { get; set; }
        public String Code { get; set; }
        public String Location { get; set; }
        public double ValumePerUnit { get; set; }
        public String Supplier { get; set; }
        public String Date { get; set; }
        public int Count;
        private String ID { get; set; }
        
        public void setID()
        {
            ID = Convert.ToString(Guid.NewGuid());
        }

        public String getID()
        {
            return ID;
        }


        public Good(String Name=null, double Price = 0, String Code = null, double ValumePerUnit = 0, String Supplier = null,int Count = 1)
        {
            if (Name != null || Code != null)
            {
                this.Name = Name;
                this.Price = Price;
                this.Code = Code;
                this.ValumePerUnit = ValumePerUnit;
                this.Supplier = Supplier;
                this.Count=Count;
                

            }
            else
                throw new Exception("something went wrong with the product details");
        }

        public double getValume()
        {
            return ValumePerUnit;
        }

        public String getLocation()
        {
            return Location;
        }

        public void Display_GoodDetials()
        {
            Console.Write($"Good Details are the following..." +
                $"\n  Name: {Name}\n  Price: {Price}\n  Supplier: {Supplier}");
        }

        


        public void productCodeReader(String Code)
        {
        



        }
        


    }
}


