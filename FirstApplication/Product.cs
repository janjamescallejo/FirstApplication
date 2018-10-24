using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstApplication
{
    public class Product
    {
        public int ProductID;
        public string ProductPic;
        public string ProductName;
        public string ProductDescription;
        public string ProductCategoryA;
        public string ProductCategoryB;
        public string ProductCategoryC;
        public double ProductPrice;
        public int ProductQuantity;

        public Product(int productID, string productPic, string productName, string productDescription, string productCategoryA, string productCategoryB, string productCategoryC, double productPrice, int productQuantity)
        {
            ProductID = productID;
            ProductPic = productPic;
            ProductName = productName;
            ProductDescription = productDescription;
            ProductCategoryA = productCategoryA;
            ProductCategoryB = productCategoryB;
            ProductCategoryC = productCategoryC;
            ProductPrice = productPrice;
            ProductQuantity = productQuantity;
        }
    }
}