using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class Delivery
    {
        string deliveryID;
        DateTime deliveryDate;
        Random random = new Random();

        private string generatedeliveryID() {
            int length = 4;
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
           
        }

        public Delivery()
        {
            this.deliveryID="DELIVERY"+generatedeliveryID();
            this.deliveryDate = DateTime.Now;
        }

        private string address;
        private string parcelID;
        private string parcelType;
        private string userID;
        private string deliveryStatus;
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

       

        public string ParcelID
        {
            get
            {
                return parcelID;
            }

            set
            {
                parcelID = value;
            }
        }

        public string ParcelType
        {
            get
            {
                return parcelType;
            }

            set
            {
                parcelType = value;
            }
        }

        public string DeliveryID
        {
            get
            {
                return deliveryID;
            }

            
        }

        public DateTime DeliveryDate
        {
            get
            {
                return deliveryDate;
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

        public string DeliveryStatus
        {
            get
            {
                return deliveryStatus;
            }

            set
            {
                deliveryStatus = value;
            }
        }
    }
}