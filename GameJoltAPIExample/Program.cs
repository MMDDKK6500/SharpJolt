using System;
using gamejoltapiCore;
using gamejoltapiTrophies;

namespace GameJoltAPIExample
{
    class Program
    {
        static void Main()
        {
            GJCore c = new GJCore("86282091", "9021he90h9210");
            GJTrophies t = new GJTrophies(c, "245622");
            Console.WriteLine(c);
            Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}
