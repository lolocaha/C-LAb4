using System;
using System.Collections.Generic;

namespace ConsoleApp8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // z1
            Console.WriteLine("--- z1 ---");
            List<object> L = new List<object> { 1, 2, 3, 4, 5 };
            List<object> L1 = new List<object> { 3, 4 };
            List<object> L2 = new List<object> { 9, 9, 9 };
            ListWork.z1(L, L1, L2);

            // z2
            Console.WriteLine("--- z2 ---");
            ListWork.z2(new LinkedList<int>(new int[] { 1, 8, 9, 3, 4, 1, 0 }));
            ListWork.z2(new LinkedList<char>(new char[] { 'd', 'a', 'c', 'b', 'a' }));
            ListWork.z2(new LinkedList<string>(new string[] { "pear", "apple", "fig", "banana" }));

            // z3
            Console.WriteLine("--- z3 ---");
            HashSet<string> games = new HashSet<string> { "Dota", "Minecraft", "Chess", "Doom" };
            Dictionary<string, HashSet<string>> students = new Dictionary<string, HashSet<string>>();
            students.Add("Аня", new HashSet<string> { "Dota", "Chess" });
            students.Add("Борис", new HashSet<string> { "Dota", "Minecraft", "Chess" });
            students.Add("Вика", new HashSet<string> { "Chess" });
            ListWork.z3(students, games);


            // z4
            Console.WriteLine("--- z4 ---");
            ListWork.z4("lol.txt");

            // z5
            Console.WriteLine("--- z5 ---");
            ListWork.z5();







        }
    }
}
    
