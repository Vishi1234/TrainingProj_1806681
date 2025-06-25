using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3
{

    class SalesDetail
    {
        private int salesno;
        private int productno;
        private int price;
        private int dateofSale;
        private int Qty;
        //private int TotalAmt;


        public SalesDetail(int salesno, int productno, int price, int Qty, int dateofSale)
        {
            this.salesno = salesno;
            this.productno = productno;
            this.price = price;
            this.Qty = Qty;
            this.dateofSale = dateofSale;
            //this.TotalAmt = TotalAmt;
        }

        public void Sales()
        {
            int TotalAmt;
            TotalAmt = Qty * price;
            Console.WriteLine("the total amount is" + " " +  TotalAmt);
        }

        public void ShowData()
        {
            Console.WriteLine($"Sales no.: {salesno}");
            Console.WriteLine($"Product no: {productno}");
            Console.WriteLine($"price {price}");
            Console.WriteLine($"quatity: {Qty}");
            Console.WriteLine($"Date: {dateofSale}");

        }
    }

        internal class Program3
    {
        public static void Main()
        {
            Console.WriteLine("enter sales no");
            int salesno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter product no");
            int productno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter price");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter quantity");
            int Qty = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter date");
            int dateofSale = Convert.ToInt32(Console.ReadLine());

            SalesDetail sd = new SalesDetail(salesno, productno, price, Qty, dateofSale );
            sd.Sales();
            sd.ShowData();
            Console.ReadLine();

        }
    }
}
