using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class UserAccount
    {
        public int id;
        public string uName;
        public string pWord;

        public UserAccount(int id, string uName, string pWord)
        {
            this.id = id;
            this.uName = uName;
            this.pWord = pWord;
        }
    }
}