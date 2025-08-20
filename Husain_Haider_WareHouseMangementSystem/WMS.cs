using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Threading.Tasks;



namespace WareHouseMangementSystem
{


    internal class WMS
    {
        static void Main(String[] args)
        {

            //  InitializeArray for the storage

            var storge = new Storge();
            storge.prepairStorage();





            while (true)
            {
                Console.WriteLine("Choose your window:\n  1.workers window\n  2.client window");
                Console.Write("-> ");
                int window = Convert.ToInt32(Console.ReadLine());

                switch (window) { 
                
                    case 1:
                        {
                            //  workers window

                            //  First call the warehouse security to prepare Warehouse security and manger accounts
                            WarehouseSecurity security = new WarehouseSecurity();
                            security.AddTheMangerAccounts();

                            ////  call the admin to log in as manger or staff
                            Administrator administrator = new Administrator();

                            administrator.Verify_PassWord();
                            break;
                        }
           
                        case 2:
                        {

                            //  client window
                            Console.WriteLine($"Hello client You wana buy or sell today...");
                            Console.WriteLine($"  1.Buying\n  2.Selling");
                            int ClientType = Convert.ToInt16(Console.ReadLine());

                            switch (ClientType)
                            {
                                case 1:
                                    {

                                        var Customer = new Customer();
                                        break;
                                    }

                                case 2:
                                    {
                                        var suplier = new Suppliers();

                                        break;
                                    }
                            }
                            break;
                        }

            }

        }

    }
}
}
