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
            if (L1 == null || L1.Count == 0)
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
                L.RemoveRange(index, L1.Count);

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
            if (l.Count == 0) { Console.WriteLine("Нет студентов"); return; }
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
                    alph.Remove(char.ToLower(word));
                }
            }
            catch (FileNotFoundException)
            {


                Console.WriteLine("Ошибка: сам файл не найден.");
                return;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Путь не найден");
                return;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Неверный путь");
                return;
            }
            foreach (char s in alph)
            {
                Console.WriteLine(s);
            }
        }
        public static void z5()
        {
            int n;
            while (true)
            {
                Console.WriteLine("Введите количество участников:");
                if (int.TryParse(Console.ReadLine(), out n) && n >= 1 && n <= 250) break;
                Console.WriteLine("Неверный ввод: нужно целое число от 1 до 250");
            }

            List<string> leaders = new List<string>();
            int max = -1;

            for (int i = 0; i < n; i++)
            {
                string name;
                int sum;
                while (true)
                {
                    Console.WriteLine("Введите данные:");
                    if (TryParseLine(Console.ReadLine(), out name, out sum)) break;
                    Console.WriteLine("Неверный ввод");
                }

                if (sum > max) { max = sum; leaders.Clear(); leaders.Add(name); }
                else if (sum == max) { leaders.Add(name); }
            }
            Console.WriteLine("Вывод:");
            foreach (string s in leaders)
                Console.WriteLine(s);
        }

        public static bool TryParseLine(string input, out string name, out int sum)
        {
            name = null;
            sum = 0;
            if (input == null) return false;

            string[] p = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (p.Length != 5) return false;
            if (p[0].Length > 20 || p[1].Length > 15) return false;

            for (int k = 2; k < 5; k++)
            {
                int x;
                if (!int.TryParse(p[k], out x) || x < 0 || x > 25) return false;
                sum += x;
            }

            name = p[0] + " " + p[1];
            return true;
        }

    }
    
}