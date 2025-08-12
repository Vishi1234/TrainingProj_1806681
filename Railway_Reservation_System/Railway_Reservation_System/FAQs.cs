using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System
{
    internal class FAQs
    {
        public static void FAQuestions()
        {
            Console.WriteLine("Q1. How to book a ticket?");
            Console.WriteLine("Q2. How to view all the trains?");
            Console.WriteLine("Q3. How to cancel my ticket");
            Console.WriteLine("Q4. What is the return policy");
            Console.WriteLine();
            Console.WriteLine("<-- Go Back");
            Console.WriteLine();
            Console.Write("Enter your choice (1,2,3 or 4) or press 5 to go back to main menu: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (choice) {
                case 1:
                    Console.WriteLine("Ans: First register yourself on the application then login with the same credentials, among the user options first view all trains then select book a train enter the asked details and the ticket will be booked.");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Ans: Login with your credentials and select the option view all trains");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Ans: Login with your credentials then select cancel my ticket, enter the seat number and pnr no to cancel");
                    Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Ans: Once you cancel the ticket you get 50% refund of the cncelled ticket");
                    Console.ReadLine();
                    break;
                case 5:
                    RegistrationOptions.Options();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    Console.Write("Press 'y' to choose again: ");
                    char ans = Convert.ToChar(Console.ReadLine());
                    if (ans == 'Y' || ans == 'y')
                    {
                        FAQs.FAQuestions();
                    }
                    break;
            }
        }
    }
}
