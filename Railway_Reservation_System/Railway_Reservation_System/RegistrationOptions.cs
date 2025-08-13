using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railway_Reservation_System
{
    internal class RegistrationOptions
    {
        public static void Options()
        {
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Railway Reservation System");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Console.WriteLine("1. Login as User");
            Console.WriteLine("2. Login as admin");
            Console.WriteLine("3. New? Register here");
            Console.WriteLine("4. FAQs");
            Console.WriteLine();
            Console.Write("Enter Your Choice: ");
            int choice = Convert.ToInt32 (Console.ReadLine());

            switch (choice)
            {
                case 1:
                    UserLogin.LoginAsUser();
                    break;
                case 2:
                    AdminLogin.LoginAsAdmin();
                    break;
                case 3:
                    Register.RegisterUser();
                    break;
                case 4:
                    FAQs.FAQuestions();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.Write("Press Y to go back to the main menu: ");
                    char ans = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine();

                    if (ans == 'y' || ans == 'Y')
                    {
                        RegistrationOptions.Options();
                    }


                    return;
            }
        }
    }
}
