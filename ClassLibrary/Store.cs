using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Store
    {
        public static int NotebookLimit { get; set; }
        public static int PhoneLimit { get; set; }

        public Product [] notebooks = new Product[0];

        public Product[] phones = new Product[0];

        public Product[] Products = new Product[0];
        
        public void AddProduct(Product products)
        {
            if(products is Notebook)
            {
                Array.Resize(ref notebooks, notebooks.Length + 1);
                notebooks[notebooks.Length - 1] = products;

                if (notebooks.Length <= NotebookLimit)
                {
                    Array.Resize(ref Products, Products.Length + 1);
                    Products[Products.Length - 1] = products;
                }
            }
           else if(products is Phone)
            {
                Array.Resize(ref phones, phones.Length + 1);
                phones[phones.Length - 1] = products;

                if (phones.Length <= PhoneLimit)
                {
                    Array.Resize(ref Products, Products.Length + 1);
                    Products[Products.Length - 1] = products;
                }
            }

        }
        public string FindByNo(int no)
        {
            for (int i = 0; i < Products.Length; i++)
            {
                if (no == Product.No)
                {
                    return Products[i].Name;
                }
            }
            return "yoxdur";
        }

        public double CalcNotebookAvg()
        {
            double sum = 0;
            int count = 0;
            for (int i = 0; i < notebooks.Length; i++)
            {
                if(Products[i] is Notebook)
                {
                    Notebook notebookss = Products[i] as Notebook;
                    count++;
                    sum += notebookss.Price * (100 - notebookss .DiscountPercent) / 100;
                }
            }return sum / count;
        }

        public double CalcPhoneAvg()
        {
            double sum = 0;
            int count = 0;
            for (int i = 0; i < phones.Length; i++)
            {
                if (Products[i] is Phone)
                {
                    Phone phoness = Products[i] as Phone ;
                    count++;
                    sum += phoness.Price * (100 - phoness.DiscountPercent) / 100;
                }
            }
            return sum / count;
        }

    }
}
