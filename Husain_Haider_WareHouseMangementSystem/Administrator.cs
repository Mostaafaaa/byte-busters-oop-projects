using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WareHouseMangementSystem
{
    public class Administrator
    {
        WarehouseSecurity Security = new WarehouseSecurity();
        public String name {  get; set; }
        private String PassWord { get; set; }
      

        //  login to account and get userID for Saff or Manger member
        public void login(String UserID , String Name)
        {
            //  if the user ID is One of the mangers it will access the Manger Account
            List<String> Mangers_IDs = Security.MangersIDs();

            if (Mangers_IDs.Contains(UserID))
            {
                var accessManger = new Manger(Name, UserID);
            }
            else if (UserID.StartsWith("S"))
            {
                var accessSaff = new Staff(Name, UserID);
            }
            else
            {
                Console.WriteLine("somthing got wrong with the ID");
            }
        }


        //  checks the given password and verify it
        public void Verify_PassWord(String aName = null, String aPassWord = null)
        {
            name = aName;
            PassWord = aPassWord;
            if ((aName == null) & (aPassWord == null))
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine();
                Console.Write("Enter Password: ");
                PassWord = Console.ReadLine();

            }
            Security.Validate_PassWord(name, PassWord);
        }


    }
}
