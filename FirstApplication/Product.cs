using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class Product
    {
        private string productID;
        private string productPic;
        private string productName;
        private string productDescription;
        private string productCategoryA;
        private string productCategoryB;
        private string productCategoryC;
        private double productPrice;
        private int productQuantity;
        private string userID;
        private DateTime productDate;

        public string ProductID
        {
            get
            {
                return productID;
            }

            set
            {
                productID = value;
            }
        }

        public string ProductPic
        {
            get
            {
                return productPic;
            }

            set
            {
                productPic = value;
            }
        }

        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                productName = value;
            }
        }

        public string ProductDescription
        {
            get
            {
                return productDescription;
            }

            set
            {
                productDescription = value;
            }
        }

        public string ProductCategoryA
        {
            get
            {
                return productCategoryA;
            }

            set
            {
                productCategoryA = value;
            }
        }

        public string ProductCategoryB
        {
            get
            {
                return productCategoryB;
            }

            set
            {
                productCategoryB = value;
            }
        }

        public string ProductCategoryC
        {
            get
            {
                return productCategoryC;
            }

            set
            {
                productCategoryC = value;
            }
        }

        public double ProductPrice
        {
            get
            {
                return productPrice;
            }

            set
            {
                productPrice = value;
            }
        }

        public int ProductQuantity
        {
            get
            {
                return productQuantity;
            }

            set
            {
                productQuantity = value;
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

        public DateTime ProductDate
        {
            get
            {
                return productDate;
            }

            set
            {
                productDate = value;
            }
        }
    }
}