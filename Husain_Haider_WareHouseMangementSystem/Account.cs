using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseMangementSystem
{
    public class Account
    {
        public String name { set; get; }
        public String PassWord { set; get; }
        public String UserID { set; get; }
        public Account(String aName,String aPassWord , String aUserID) 
        {
            name = aName;
            PassWord = aPassWord;
            UserID = aUserID;
        }
    }
}
