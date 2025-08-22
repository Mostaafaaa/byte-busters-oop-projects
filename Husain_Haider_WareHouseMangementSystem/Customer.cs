using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseMangementSystem
{
    internal class Customer : Clients
    {
        public Customer()
        {

            Console.WriteLine(Name, ID, Adress, Number);
            Buy();

        }
        public void Buy()
        {


            //  here we use linq to check all goods for name of what the custromer wants to buy
            //foreach (var Goods in this) {
            //  calling storage to Display All Goods Availble

            Slot.DisplayAllGoodsAvailble();

            BuyProduct();

        }

        //  the customer must enter name and how much product to purches the product
        public void BuyProduct()
        {
            Console.WriteLine("enter name of product You want?");
            String ProductName = Console.ReadLine();
            Console.WriteLine("enter how much of product You want?");
            int HowMuch = Convert.ToInt32(Console.ReadLine());

            int Count = 0;
            foreach (var slot in Storge.newOder)
            {

                for (int i = slot.goods.Count - 1; i >= 0; i--)
                {
                    if (slot.goods[i].Name == ProductName && Count != HowMuch)
                    {
                        Count++;
                        slot.goods.RemoveAt(i);

                    }
                    else
                    {
                        break;
                    }
                }


            }
        }
    }
}