using System;
using System.Runtime;

using System.Linq;
using System.Collections.Generic;
namespace WareHouseMangementSystem;
using System.Text.RegularExpressions;

    class Storge
    {
        //  after considration i am going to build a 200 square meters of warehouse 
        //  that uses about 150 square to store things
        //  and knowing that i can use 50 slots of 3 square meters each 
        //  and let say that height is 3 meter so it would be 2 levels 1.3 hight for each slot
        //  meaning 100 slots is used and each size it 3x3x1.3 = 11.7 cub meters

        public static Slot[,] slots = new Slot[50, 2];

     

        //  InitializeArray make sure that all slots of the array are objects without null value
        public void InitializeArray()
        {
            int numbering = 0;
            for (int i = 0;i <= 1;i++) 
            { 
               for (int j =0;j<=49;j++){
                    slots[j,i] = new Slot();

                }
      
            }
            
        }

        //  making a slot names or ID using letter + 2 numbers 
        //  the letter is the group and the 2 numbers are the location of slot in the group
        //  example A01 or H13 
        public char[] slotNamingLetters = { 'A','B' ,'C','D','E','F','G','H','I'};
        public static List<Slot> newOder = new List<Slot>();
        public void namingArrays()
            {
            
            List<String> NamingSlotsList=new List<String>();
            foreach (char l in slotNamingLetters)
            {
                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        NamingSlotsList.Add(l+$"{j}{i}");
                    }
                }
            }


        //  here we assigne the id to the slot unit all slots are assigned
        int c = 0;
            foreach (Slot slot in slots)
            {
                try
                {
                    
                    slot.SlotID = NamingSlotsList[c];
                    c++;
                   
                }
                catch
                {
                    break;
                }

            }

            //  here we make the order by the slot ID 
            var OrderArray = slots.Cast<Slot>().OrderBy(x => x.SlotID).ToArray();

            foreach (var i in OrderArray)
            {
                Console.WriteLine(i.SlotID);
            }



            //  specify how the oder is by makeing two groups lower level then upper level cell by cell
            //  so at the end we can fill by that order

            var array10s = slots.Cast<Slot>().Where(x => Regex.IsMatch(x.SlotID,@"^[A-Za-z]1\d")).ToArray();
            var array1s = slots.Cast<Slot>().Where(x => Regex.IsMatch(x.SlotID, @"^[A-Za-z]0\d")).ToArray();

            
        int index = 0;
        while(true) 
        {
            try
            {
                newOder.Add(array1s[index]);
                newOder.Add(array10s[index]);

                index++;
            }
            catch
            {
                break;
            }

        }

        //  just a showCase how both oders works fin
        foreach (var i in OrderArray)
            {
                Console.WriteLine(i.SlotID);
            }

        foreach (var i in newOder)
        {
            Console.WriteLine(i.SlotID);
        }

    }

    //  to prepare the slots to store info about goods we must execute both methods
    public void prepairStorage()
        {
            InitializeArray();
            namingArrays();
        }





        //  available prodects of all slots




        private String Movement_Summery;

        public void Search()
        {

        }
        public void IsFull()
        {

        }

        
        public void CalculatingAllGoodsAvailble()
        {
        //  we clear to prvent overlaping with previous calcultion of Goods

        var slot1 = new Slot();
        slot1.resetAllGoodsCountings();
        foreach (Slot slot in newOder)
        {
            slot.resetAllGoodsCountings();
        }


            foreach (Slot slot in newOder)
            {
            if(slot.SlotSize()!= "   Empty  ")
                slot.goodsAvailbeInSlot();
            }
        }

      

        public void GoodsInsertingSystem(Good good)
        {
        double GoodCount = good.Count;
        good.Count = 1;
        foreach (var s in newOder)
        {
            if (GoodCount >= 1)
            {
                while (GoodCount >= 1)
                {
                    if (s.CanFit(good.ValumePerUnit))
                    {
                        GoodCount--;

                        
                        s.addNewProduct(good);
                        s.CurrentSlotSize += good.ValumePerUnit;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
                break;
        }

        //  calculating goods Availble after goods Inserted

        CalculatingAllGoodsAvailble();


      
    }




        public void ViewStorage()
    {

        

        foreach (var group in slotNamingLetters)
        {
            var g1 = Storge.newOder.Where(x => Regex.IsMatch(x.SlotID, @$"^{group}0\d")).ToList();
            var g2 = Storge.newOder.Where(x => Regex.IsMatch(x.SlotID, @$"^{group}1\d")).ToList();

            var groupFilter = g2.Concat(g1).ToList();

            //  first the top of table must be drawen
            Console.WriteLine("┌──────────┬──────────┬──────────┬──────────┬──────────┬──────────┐");

            int SlotIndex = 0;
            int count = 0;
            foreach (Slot item in groupFilter)
            {
                count++;
                if (count > 6)
                {
                    Console.Write("│\n");
                    //  this loop is for size of slot
                    for (int i = 0; i < 6; i++)
                    {
                        Console.Write($"│{groupFilter[SlotIndex].SlotSize()}");
                        SlotIndex++;

                    }
                    Console.Write("│\n");
                    Console.WriteLine("├──────────┼──────────┼──────────┼──────────┼──────────┼──────────┤");
                    count = 0;
                }

                Console.Write($"│    {item.SlotID}   ");

                if (item == groupFilter.Last())
                {
                    try
                    {
                        Console.Write("│\n");
                        for (int i = 0; i < 6; i++)
                        {
                            Console.Write($"│{groupFilter[SlotIndex].SlotSize()}");
                            SlotIndex++;
                        }
                        Console.Write("│");
                    }
                    catch
                    {

                    }
                }

            }



            //  last the bottom must drawen
            Console.WriteLine("\n└──────────┴──────────┴──────────┴──────────┴──────────┴──────────┘");
            Console.WriteLine($"\t\t\t\tSlot:{group}");


        }
    }
        // ضيف insert good 
        // واذا مليان المساحة للسلوت حول على الوراها ببساطة
        // اخزن الموقع واطيه للسلون و الكود
    }

