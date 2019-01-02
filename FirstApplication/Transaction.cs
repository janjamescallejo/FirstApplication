using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class Transaction
    {
        private string transactionID;
        private Product transactionItem;
        private int transactionQuantity;
        private double transactionPrice;
        private string userID;

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

        
        public int TransactionQuantity
        {
            get
            {
                return transactionQuantity;
            }

            set
            {
                transactionQuantity = value;
            }
        }

        public double TransactionPrice
        {
            get
            {
                return transactionPrice;
            }

            set
            {
                transactionPrice = value;
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

        public Product TransactionItem
        {
            get
            {
                return transactionItem;
            }

            set
            {
                transactionItem = value;
            }
        }
    }
}