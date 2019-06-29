using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class TransactionDetails
    {
        private string transactionID;
        private string userID;
        private double transactionCash;
        private double transactionChange;
      

        public string TransactionID
        {
            get
            {
                return transactionID;
            }

            set
            {
                transactionID = value;
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

        public double TransactionCash
        {
            get
            {
                return transactionCash;
            }

            set
            {
                transactionCash = value;
            }
        }

        public double TransactionChange
        {
            get
            {
                return transactionChange;
            }

            set
            {
                transactionChange = value;
            }
        }
        
    }
}