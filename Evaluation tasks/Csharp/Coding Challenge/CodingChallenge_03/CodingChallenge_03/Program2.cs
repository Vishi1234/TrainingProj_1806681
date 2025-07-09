using System;

namespace CodingChallenge_03
{
    class Box
    {
        public int length;
        public int breadth;


        public static Box operator +(Box Box1, Box Box2)
        {
            Box temp = new Box();
            temp.length = Box1.length + Box2.length;
            temp.breadth = Box1.breadth + Box2.breadth;
            return temp;
        }
    }
    internal class Program2
    {
        static void Main()
        {
            Box b1 = new Box();
            Console.WriteLine("enter the length for box1");
            b1.length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the breadth for box1");
            b1.breadth = Convert.ToInt32(Console.ReadLine());
            Box b2 = new Box();
            Console.WriteLine("enter the length for box2");
            b2.length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the breadth for box2");
            b2.breadth = Convert.ToInt32(Console.ReadLine());

            Box b3 = b1 + b2;
            Console.WriteLine($"The overall length and breadth of Box3 is {b3.length} and {b3.breadth} respectively");
            Console.ReadLine();
        }
    }
}

