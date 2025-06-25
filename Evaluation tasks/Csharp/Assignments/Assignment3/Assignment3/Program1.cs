using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{

    class Accounts
    {
        private int accno;
        private string customer_name;
        private string account_type;
        private string transac_type;
        private int Amt;
        private int balance = 0;

        public Accounts(int accno, string customer_name, string account_type, string transac_type,
            int Amt, int balance)
        {
            this.accno = accno;
            this.customer_name = customer_name;
            this.account_type = account_type;
            this.transac_type = transac_type;
            this.Amt = Amt;
            this.balance = balance;
        }

        public void Credit()
        {
            balance = balance + Amt;
            Console.WriteLine("balance is" + " " + balance);
        }

        public void Debit()
        {
            balance -= Amt;
            Console.WriteLine("balance is" + " " + balance);
        }

        public void Update()
        {
            if (transac_type == "deposit")
            {
                Credit();
            }
            else if (transac_type == "withdraw")
            {
                Debit();
            }
            else
            {
                Console.WriteLine("invalid type");
            }
        }

        public void ShowData()
        {
            Console.WriteLine($"acc no.: {accno}");
            Console.WriteLine($"customer name: {customer_name}");
            Console.WriteLine($"acc type {account_type}");
            Console.WriteLine($"transaction type: {transac_type}");
            Console.WriteLine($"amount: {Amt}");
        }
    }
        internal class Program1
    {
            public static void Main()
            {
                Console.WriteLine("enter acc no");
                int accno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter customer name");
                string customer_name = Console.ReadLine();
                Console.WriteLine("enter acc type");
                string account_type = Console.ReadLine();
                Console.WriteLine("enter transaction type");
                string transac_type = Console.ReadLine();
                Console.WriteLine("enter amount");
                int Amt = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter initial balance");
                int balance = Convert.ToInt32(Console.ReadLine());

            Accounts acc = new Accounts(accno, customer_name, account_type, transac_type, Amt, balance);
            acc.Update();
            acc.ShowData();
            Console.ReadLine();
            }
    }
}
