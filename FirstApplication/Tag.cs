using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class Tag
    {
        string tagID;
        string tagName;
        string tagDescription;
        string userID;
        DateTime tagDate;

        public string TagID
        {
            get
            {
                return tagID;
            }

            set
            {
                tagID = value;
            }
        }

        public string TagName
        {
            get
            {
                return tagName;
            }

            set
            {
                tagName = value;
            }
        }

        public string TagDescription
        {
            get
            {
                return tagDescription;
            }

            set
            {
                tagDescription = value;
            }
        }

        public string UserID
        {
            get
            {
                return userID;
            }

            set
            {
                userID = value;
            }
        }

        public DateTime TagDate
        {
            get
            {
                return tagDate;
            }

            set
            {
                tagDate = value;
            }
        }
    }
}