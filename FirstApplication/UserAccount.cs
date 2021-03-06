﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class UserAccount
    {
        private string id;
        private string uName;
        private string pWord;
        private string userType;
        private DateTime userDate;

        public string Id
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

        public string UserType
        {
            get
            {
                return userType;
            }

            set
            {
                userType = value;
            }
        }

        public DateTime UserDate
        {
            get
            {
                return userDate;
            }

            set
            {
                userDate = value;
            }
        }
    }
}