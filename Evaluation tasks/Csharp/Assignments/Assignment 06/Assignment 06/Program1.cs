using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_06
{
    class Books
    {
        public string[] BookName = new string[5];
        public string[] AuthorName = new string[5];

        public string this[int index]
        {
            get { return BookName[index]; }
            set { BookName[index] = value; }
        }
        public string this[float index]
        {
            get { return AuthorName[(int)index]; }
            set { AuthorName[(int)index] = value; }
        }

        public void BookShelf()
        {
            BookName[0] = "To Kill a Mockingbird";
            AuthorName[0] = "Harper Lee";

            BookName[1] = "Half Girlfriend";
            AuthorName[1] = "Chetan Bhagat";

            BookName[2] = "The Girl on the Train";
            AuthorName[2] = "Paula Hawkins";

            BookName[3] = "13 Reasons Why";
            AuthorName[3] = "Jay Asher";

            BookName[4] = "Harry Potter";
            AuthorName[4] = "J.K. Rowling";
        }

        public void Display()
        {
            for (int i = 0; i < BookName.Length; i++)
            {
                Console.WriteLine($"Book {i + 1}: \"{BookName[i]}\" by {AuthorName[i]}");
            }
        }
    }

    internal class Program1
    {
        static void Main()
        {
            Books shelf = new Books();
            shelf.BookShelf();
            shelf.Display();
            Console.ReadLine();
        }
    }
}