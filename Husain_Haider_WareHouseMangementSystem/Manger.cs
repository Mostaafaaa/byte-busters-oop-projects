using System.Net.Http.Headers;

namespace WareHouseMangementSystem
{
    internal class Manger
    {
        public String MangerName { get; set; }
        public String MangerID { get; set; }

        //  client list (buying or selling)
        private List<Clients> clients = new List<Clients>();

        public Manger(String MangerName, String MangerID)

        {
            bool Logedin = true;
            while (Logedin)
            {

                var Security = new WarehouseSecurity();

                this.MangerID = MangerID;
                this.MangerName = MangerName;
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                Console.WriteLine($"  hi manger {this.MangerName} ID: {this.MangerID}");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

                Console.Write($"what you want to do:\n  1.Add an account\n  2.Delete an account\n  3.View all accounts");
                Console.WriteLine($"\n  4.View Storage\n  5.Edit Client\n  6.View Clients\n  7.Logout");
                Console.Write("-> ");
                
               
                    int Choise = Convert.ToInt16(Console.ReadLine());

                    switch (Choise)
                    {
                        case 1:
                            {
                                Console.Write("Account Name: ");
                                String Name = Console.ReadLine();

                                Console.Write("Account PassWord: ");
                                String PassWord = Console.ReadLine();


                                Console.Write("Genrating ID for account");


                                String ID = 'S' + Convert.ToString(Guid.NewGuid());

                                var newAccount = new Account(Name, PassWord, ID);
                                Security.addAccount(newAccount);
                                break;
                            }
                        case 2:
                            {
                                Console.Write("enter Name for the Account u want to delete: ");
                                String Name = Console.ReadLine();
                                Security.deleteAccount(Name);
                                break;


                            }

                        case 3:
                            {
                                Security.ViewAccounts();
                                break;
                            }


                        //  Adding client here
                        //  there is 2 types buying or selling

                        //  here we view storage then futher option about the storage table
                        case 4:
                            {


                                var storage = new Storge();
                                storage.ViewStorage();


                                bool cancel = false;
                                while (!cancel)
                                {
                                    Console.WriteLine("1. zoom in❌\n2. looking for product\n3. cancel");
                                    int tableOptions = Convert.ToInt32(Console.ReadLine());
                                    switch (tableOptions)
                                    {
                                        case 1:
                                            {
                                                break;
                                            }
                                        case 2:
                                            {

                                                String productName = Console.ReadLine();
                                            var prductDetails = (Slot.availableGoods.Where(x => x.Name == productName)).ToList();
                                            Console.WriteLine($"\t{prductDetails[0].Name}\t${prductDetails[0].Price}\t{prductDetails[0].Supplier}\tavailable: {prductDetails[0].Count}");
                                            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                                            List<Good> prductSearch = new List<Good>();
                                            foreach (var slot in Storge.newOder)
                                            {
                                                foreach(var p in slot.goods)
                                                {
                                                    if (p.Name == productName)
                                                    {
                                                        p.Location = slot.SlotID;
                                                        prductSearch.Add(p);
                                                    }
                                                }
                                                
                                            }
                                            foreach (Good p in prductSearch)
                                            {
                                                Console.WriteLine($"ID:\t{p.getID()}  ->  Location:\t{p.getLocation()}");
                                            }
                                            break;
                                            }
                                        case 3:
                                            cancel = true; 
                                            break;
                                        default:
                                            Console.WriteLine("you must insert one of the option above...");
                                            break;

                                    }
                                }
                                cancel = false;



                                break;
                            }
                    case 7:
                        {
                            Logedin = false;
                            break;
                        }
                        default:
                            {
                                Console.WriteLine("you must enter one of the numbers above try again...");
                                break;
                            }




                    }
                    Console.WriteLine();


            }
            Logedin = true;


        }


    }
}
