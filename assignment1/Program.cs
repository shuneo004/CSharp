using System;
using TheManager;
#pragma warning disable // Tắt tất cả các cảnh báo

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            const int N = 19;
            Manager manager = new Manager();
            manager.init(N);
            manager.showClass();
            while (true) {            
                Console.Clear();
                manager.showClass();
                Console.WriteLine("Wanna to be continue?\n 1 for YES, rest for NO\n");
                string key = Console.ReadLine();
                if (key != "1") break;
                manager.gameShow();
                Console.ReadLine();
            }

        }
    }
}