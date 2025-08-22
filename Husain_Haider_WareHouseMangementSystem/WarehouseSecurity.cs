using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseMangementSystem
{
    public class WarehouseSecurity
    {
        private static List<Account> accountsList = new List<Account>();

        public String PassWord { get; set; }

        private int Unveiled_attempts { get; set; }
        //  Mangers Accounts

        private static String Manger1_ID = "M" + Convert.ToString(Guid.NewGuid());
        private static String Manger2_ID = "M" + Convert.ToString(Guid.NewGuid());
        private static String Manger3_ID = "M" + Convert.ToString(Guid.NewGuid());



        public List<String> MangersIDs()
        {


            List<String> MangersIDsArray = new List<String> { Manger1_ID, Manger2_ID, Manger3_ID };

            return MangersIDsArray;
        }

        public void AddTheMangerAccounts()
        {
            accountsList.Add(new Account("Husain", "1234", Manger1_ID));
            accountsList.Add(new Account("Ali", "123", Manger2_ID));
            accountsList.Add(new Account("Zeus", "12", Manger3_ID));
        }
      




        public void Validate_PassWord(String GivenName, String Entered_PassWord )
        {
            foreach (Account account in accountsList.ToList())
            {

                if ((Entered_PassWord == account.PassWord) & (GivenName == account.name))
                {
                    Administrator admin = new Administrator();
                    admin.login(account.UserID , account.name);
                }
            }
            

        }



        public void Suspend_Account()
        {

        }



        public void addAccount(Account newAccount)
        {
           
            accountsList.Add(newAccount);
            Console.WriteLine();
        }


        public void deleteAccount(String Name)
        {
            try
            {
                for (int i = accountsList.Count-1; i >= 0; i--)
                {

                    if (accountsList[i].name == Name)
                    {
                        accountsList.Remove(accountsList[i]);
                        Console.WriteLine("Account has been deleted");
                    }

                }

            }
            catch 
            {
                 
                    Console.WriteLine("there is no account with that name...");

               
            }
          
          
            
        }

        public void ViewAccounts()
        {

            foreach (Account account in accountsList)
            {

                Console.WriteLine($"{account.name}\t-\t{account.PassWord}\t-\t{account.UserID}");
            }


        }
    }
}
