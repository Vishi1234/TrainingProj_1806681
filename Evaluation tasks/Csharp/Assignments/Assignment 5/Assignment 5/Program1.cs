using System;

namespace Assignment_5
{
    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    class Accounts
    {
        private int accno;
        private string customer_name;
        private string account_type;
        private string transac_type;
        private int Amt;
        private int balance = 0;

        public Accounts(int accno, string customer_name, string account_type, string transac_type, int Amt, int balance)
        {
            this.accno = accno;
            this.customer_name = customer_name;
            this.account_type = account_type;
            this.transac_type = transac_type.ToLower();
            this.Amt = Amt;
            this.balance = balance;
        }

        public void Deposit()
        {
            if (Amt < 0)
                throw new ArgumentException("amount cannot be negative.");
            balance += Amt;
            Console.WriteLine("Balance is : " + balance);
        }

        public void Withdraw()
        {
            if (Amt < 0)
                throw new ArgumentException("amount cannot be negative.");

            if (Amt > balance)
                throw new InsufficientBalanceException("Withdrawal failed. Insufficient balance.");

            balance -= Amt;
            Console.WriteLine("Balance is : " + balance);
        }

        public void Update()
        {
            if (transac_type == "deposit")
            {
                Deposit();
            }
            else if (transac_type == "withdraw")
            {
                Withdraw();
            }
            else
            {
                Console.WriteLine("Invalid transaction type.");
            }
        }

        public void ShowData()
        {
            Console.WriteLine($"Account No: {accno}");
            Console.WriteLine($"Customer Name: {customer_name}");
            Console.WriteLine($"Account Type: {account_type}");
            Console.WriteLine($"Transaction Type: {transac_type}");
            Console.WriteLine($"Transaction Amount: {Amt}");
            Console.WriteLine($"Current Balance: {balance}");
        }
    }

    internal class Program1
    {
        public static void Main()
        {
            try
            {
                Console.Write("Enter Account Number: ");
                int accno = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Customer Name: ");
                string customer_name = Console.ReadLine();

                Console.Write("Enter Account Type: ");
                string account_type = Console.ReadLine();

                Console.Write("Enter Transaction Type (deposit/withdraw): ");
                string transac_type = Console.ReadLine();

                Console.Write("Enter Amount: ");
                int Amt = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Initial Balance: ");
                int balance = Convert.ToInt32(Console.ReadLine());

                Accounts acc = new Accounts(accno, customer_name, account_type, transac_type, Amt, balance);
                acc.Update();
                acc.ShowData();
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Transaction Failed: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input");
            }

            Console.ReadLine();
        }
    }

}
