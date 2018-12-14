using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class UserAccount
    {
        private int id;
        private string uName;
        private string pWord;
        public DateTime date;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string UName
        {
            get
            {
                return uName;
            }

            set
            {
                uName = value;
            }
        }

        public string PWord
        {
            get
            {
                return pWord;
            }

            set
            {
                pWord = value;
            }
        }

        public UserAccount(int id, string uName, string pWord)
        {
            this.Id = id;
            this.UName = uName;
            this.PWord = pWord;
            getDate();
        }
        
        private void getDate()
        {
            this.date = DateTime.Now;
        }
    }
}