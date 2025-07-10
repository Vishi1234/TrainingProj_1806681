using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatterns
{
    class Program1
    {
        static void Main()
        {

            SingleTonCache cache = SingleTonCache.GetInstance();

 
            Console.WriteLine("Adding Keys and Values to the cache");
            Console.WriteLine($"Adding EName as another key to the cache : {cache.AddOrUpdate("Sree", "Vidushi")}");
            //Console.WriteLine($"Getting all the data : {cache.GetAll()}");

            var retcd = cache.GetAll();

            foreach (var item in retcd)
            {
                Console.WriteLine($"key is : {item.Key}");
                Console.WriteLine($"vALUE IS : {item.Value}");
            }
            Console.ReadLine();
        }
    }
}