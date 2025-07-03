using System;
using System.Collections.Generic;

namespace CodingChallenge_02
{
     class  Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }

        public void Display()
        {
            Console.WriteLine("The product id is : " + " " + ProductId + "The product name is : " + " " + ProductName + "The price of the product is : " + " " + Price);
        }
    }
    
    internal class Program2
    {
        static void Main()
        {
            List<Products> products = new List<Products>();

                for (int i = 0; i<10; i++)
            {
                Console.WriteLine("Enter product id");
                int ProductId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("enter the product name");
                string ProductName = Console.ReadLine();

                Console.WriteLine("enter the price");
                int price = Convert.ToInt32(Console.ReadLine());

                products.Add(new Products
                {
                    ProductId = ProductId,
                    ProductName = ProductName,
                    Price = price,
                });
            }

                products.Sort((p1,p2) => p1.Price.CompareTo(p2.Price));
          

            Console.WriteLine("sorted");
            foreach (var prod in products)
            {
               prod.Display();
            }
            Console.Read();

        }
    }
}
