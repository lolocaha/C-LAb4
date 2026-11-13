using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
namespace ConsoleApp8
{
    public class ListWork
    {
        public static void z1(List<object> L, List<object> L1, List<object> L2)
        {
            if (L1 == null)
            {
                return;
            }
            bool Repeat = false;
            int index = -1;
            for (int i = 0; i < L.Count; i++)
            {
                if (L[i].Equals(L1[0]))
                {
                    Repeat = true;
                    for (int j = 1; j < L1.Count; j++)
                    {
                        if (i + j >= L.Count || !(L[i + j].Equals(L1[j])))
                        {
                            Repeat = false;
                            break;
                        }
                    }
                }
                if (Repeat)
                {
                    index = i;
                    break;
                }
            }
            if (Repeat)
            {
                if (L.Count > L1.Count)
                {
                    for (int l = 0; l < L1.Count; l++)
                    {
                        L.RemoveAt(index);
                    }
                }
                else
                {
                    L.RemoveRange(index, L.Count);
                }
                L.InsertRange(index, L2);
            }
            for (int k = 0; k < L.Count; k++)
            {
                Console.WriteLine(L[k]);
            }
        }
        public static void z2(LinkedList<int> L)
        {
            LinkedListNode<int> curr = L.First;
            if (L.First == null)
            {
                return;
            }
            while (curr.Next != null)
            {
                if (curr.Value > curr.Next.Value)
                {
                    L.AddFirst(curr.Next.Value);
                    L.Remove(curr.Next);
                    curr = L.First;
                }
                else { curr = curr.Next; }
              }
            curr = L.First;
            while (curr != null)
            {
                Console.WriteLine(curr.Value);
                curr = curr.Next;
            }

        }  
        public static void z2(LinkedList<string> L)
        {
            LinkedListNode<string> curr = L.First;
            if (L.First == null)
            {
                return;
            }
            while (curr.Next != null)
            {
                if (string.Compare(curr.Value,curr.Next.Value,true) > 0)
                {
                    L.AddFirst(curr.Next.Value);
                    L.Remove(curr.Next);
                    curr = L.First;
                }
                else { curr = curr.Next; }
            }
            curr = L.First;
            while (curr != null)
            {
                Console.WriteLine(curr.Value);
                curr = curr.Next;
            }

        }
        public static void z2(LinkedList<char> L)
        {
            LinkedListNode<char> curr = L.First;
            if (L.First == null)
            {
                return;
            }
            while (curr.Next != null)
            {
                if (curr.Value > curr.Next.Value)
                {
                    L.AddFirst(curr.Next.Value);
                    L.Remove(curr.Next);
                    curr = L.First;
                }
                else { curr = curr.Next; }
            }
            curr = L.First;
            while (curr != null)
            {
                Console.WriteLine(curr.Value);
                curr = curr.Next;
            }

        }

        public static void z3(Dictionary<string, HashSet<string>> l, HashSet<string> games)
        {
            HashSet<string> ans1 = new HashSet<string>();
            HashSet<string> ans2 = new HashSet<string>();
            HashSet<string> once = new HashSet<string>();
            HashSet<string> many = new HashSet<string>();
            ans1.UnionWith(games);
            foreach (HashSet<string> s in l.Values)
            {
                ans1.IntersectWith(s);
            }
            foreach (string g in ans1)
            {
                Console.WriteLine($"Задание 1: {g}");
            }
            ans2.UnionWith(games);
            foreach (HashSet<string> s in l.Values)
            {
                ans2.ExceptWith(s);
            }
            foreach (string g in ans2)
            {
                Console.WriteLine($"Задание 2: {g}");
            }

            foreach (HashSet<string> s in l.Values)
            {
                foreach (string game in s)
                {
                    if (once.Contains(game))
                    {
                        many.Add(game);
                    }
                    else
                    {
                        once.Add(game);
                    }
                }
            }
            once.ExceptWith(many);
            foreach (string g in once)
            {
                Console.WriteLine($"Задание 3: {g}");
            }
        }

        public static void z4(string path)
        {
            HashSet<char> alph = new HashSet<char> { 'п', 'ф', 'к', 'т', 'ш', 'с', 'х', 'ц', 'ч', 'щ' };
            try
            {
                string text = File.ReadAllText(path);
                foreach (char word in text)
                {
                    alph.Remove(word);
                }
            }
            catch (FileNotFoundException)
            {


                Console.WriteLine("Ошибка: сам файл не найден.");

            }
            foreach (char s in alph)
            {
                Console.WriteLine(s);
            }
        }
        public static void z5(int N)
        {
            if (N <= 0 || N > 250)
            {
                Console.WriteLine("N должно быть в пределах от 0 до 250");
                return;
            }
            
 
            Dictionary<string, int> users = new Dictionary<string, int> { };
            for (int i = 0; i < N; i++)
            {
                bool isValid = false;
                while (!isValid)
                {
                    try
                    {
                        bool isiValid = false;
                        Console.WriteLine("Введите данные:");
                        string input = Console.ReadLine();
                        string[] parts = input.Split( ' ' , count: 3);
                        string[] nums = parts[2].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        int sum = 0;
                       
                        foreach (string s in nums)
                        {
                            sum += int.Parse(s);
                        }
                        users.Add(parts[0] + " " + parts[1], sum);

                        isValid = true;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("Неверный ввод");

                    }
                }
            }
            int maxval = 0;
            foreach (int ball in users.Values)
            {
                if (ball > maxval)
                {
                    maxval = ball;
                }
            }
            foreach (var s in users)
            {   if (s.Value == maxval)
                {
                    Console.WriteLine($"{s.Key}");
                }
            }
            

        }
        
    }
    class Prog
    {
        static void Main()
        {
            ListWork.z4("lol.txt");

        }

    }
}