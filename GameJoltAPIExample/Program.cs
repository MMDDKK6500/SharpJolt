using System;
using GamejoltAPI.Core;
using GamejoltAPI.Trophies;
using GamejoltAPI.Users;

namespace GameJoltAPIExample
{
    class Program
    {
        static void Main()
        {
            GJCore c = new GJCore("86282091", "9021he90h9210");
            GJUser u = new GJUser(c, "MMDDKK", "0mad6");
            GJTrophies t = new GJTrophies(c, u);
            Console.WriteLine(c.game_id);
            Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}
