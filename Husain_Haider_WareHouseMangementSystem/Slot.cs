namespace WareHouseMangementSystem
{
    internal class Slot
    {
        public static List<Good> availableGoods = new List<Good>();

        //  the naming is like that:
        //  a b c d then each letter like that a00 a05 six slot and hight is 2 so a00 a10
        //  so each goup has 12 so let say 8 goups so a to 
        public String SlotID { set; get; }
        public List<Good> goods = new List<Good>();



        Storge storage = new Storge();
        //public void addGoodsDataBase()
        //{
        //    goods.Add(new Good("Item 1 ", 211000, "SKU-8407", 0.373, "Supplier 1"));
        //    goods.Add(new Good("Item 2 ", 179000, "SKU-6118", 0.286, "Supplier  2"));
        //    goods.Add(new Good("Item 3 ", 74500, "SKU-3789", 0.42, "Supplier 3"));
        //    goods.Add(new Good("Item 4 ", 134000, "SKU-8504", 0.471, "Supplier 4"));
        //    goods.Add(new Good("Item 5 ", 143000, "SKU-9777", 0.444, "Supplier 5"));
        //    goods.Add(new Good("Item 6 ", 88000, "SKU-5431", 0.393, "Supplier 6"));
        //    goods.Add(new Good("Item 7 ", 106000, "SKU-8134", 0.117, "Supplier 7"));
        //    goods.Add(new Good("Item 8 ", 266000, "SKU-7671", 0.29, "Supplier 8"));
        //    goods.Add(new Good("Item 9 ", 190000, "SKU-8034", 0.231, "Supplier 9"));
        //    goods.Add(new Good("Item 10 ", 36500, "SKU-8765", 0.07, "Supplier 10"));
        //}

        public void addNewProduct(Good newProduct)
        {
            goods.Add(newProduct);
            
            newProduct.setID();
        }

        
        // checkes for product to display to buyer
        // add new items to avalible list if the items are diffrent 

        public void goodsAvailbeInSlot()
        {
            foreach (Good good in goods.ToList())
            {

                if (availableGoods.Count == 0)
                {
                    availableGoods.Add(good);
                }
                else
                {

                    if (availableGoods.Contains(good))
                    {
                        availableGoods[availableGoods.IndexOf(good)].Count++;

                    }
                    else
                        availableGoods.Add(good);
                }
              

            }
        }


        public static void DisplayAllGoodsAvailble()
        {
            foreach (var available in availableGoods.ToList())
            {
                Console.WriteLine($"{available.Name}\t${available.Price}\t{available.Supplier}\tavailable: {available.Count}");
            }


        }




        //  the max size for each slot is set to be 11.7 cub meter
        public const double MaxSlotSize = 11.7;
        //  the intialize value for currentsize is zero unit good is added
        public double CurrentSlotSize = 0;
        public bool CanFit(double GoodSize)
        {
            if ((CurrentSlotSize + GoodSize) < MaxSlotSize)
            {
                return true;
            }
            else
                return false;
        }
        
        
        public String SlotSize()
        {
            if (goods.Count == 0) 
                return "   Empty  " ;
            else
            {
                return $"  {(CurrentSlotSize/MaxSlotSize)*100:N2}%  ";
            }
        }
        
        public String SlotLocation { get; set; }
        public void resetAllGoodsCountings()
        {
            foreach(var good in goods.ToList())
            {
                good.Count=1;

            }

            availableGoods.Clear();

        }

    }


   
}
//  notes
//  add isNotEmpty methode to fag not empty slots ✔️
//  show slot cotaints ✔️
//  show all slot in the wareHouse and what are empty and what are not ✔️

//  Zoom in foreach group to see more detail like products name count + how much space left
//  most important: search for product and identify where it is being stored