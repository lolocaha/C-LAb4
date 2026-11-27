using System;
using System.Collections.Generic;
using System.Text;
using static MoneyWork;

namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----z6_z7-------");
            Money a = new Money(5, 20);
            Console.WriteLine("Изначальное значение   "+ a.ToString());             
            Console.WriteLine("a + 150   " + (a + 150).ToString());     
            Console.WriteLine("150 + a   " +(150 + a).ToString());       
            Console.WriteLine("a - 150   " +(a - 150).ToString());       
            Console.WriteLine("1000 - a  " + (1000 - a).ToString());      

            Money b = new Money(5, 20);
            b++;
            Console.WriteLine("b++      = " + b.ToString());               
            b--;
            b--;
            Console.WriteLine("b-- --   = " + b.ToString());              

            Console.WriteLine("(uint)a  = " + ((uint)a).ToString());       
            double d = a;
            Console.WriteLine("double   = " + d.ToString());             

            Console.WriteLine();
            Console.WriteLine("--- Ввод с клавиатуры ---");
            uint rubles = ReadUint("Введите рубли: ", uint.MaxValue);
            uint kop = ReadUint("Введите копейки (0-99): ", 99);
            uint l = ReadUint("Введите число копеек для + и -: ", uint.MaxValue);

            Money m = new Money(rubles, (byte)kop);
            Console.WriteLine("m        = " + m.ToString());
            Console.WriteLine("m + n    = " + (m + l).ToString());
            Console.WriteLine("n + m    = " + (l + m).ToString());

            try
            {
                Console.WriteLine("m - n    = " + (m - l).ToString());
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("m - n    : ошибка, сумма стала бы отрицательной");
            }

            try
            {
                Console.WriteLine("n - m    = " + (l - m).ToString());
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("n - m    : ошибка, сумма стала бы отрицательной");
            }

            Money inc = new Money(rubles, (byte)kop);
            inc++;
            Console.WriteLine("m++      = " + inc.ToString());

            try
            {
                Money dec = new Money(rubles, (byte)kop);
                dec--;
                Console.WriteLine("m--      = " + dec.ToString());
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("m--      : ошибка, сумма стала бы отрицательной");
            }

            Console.WriteLine("(uint)m  = " + ((uint)m).ToString());
            double dm = m;
            Console.WriteLine("double   = " + dm.ToString());
        }
        private static uint ReadUint(string prompt, uint max)
        {
            uint value;
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (uint.TryParse(s, out value) && value <= max)
                {
                    return value;
                }
                Console.WriteLine("Неверный ввод: нужно целое число от 0 до " + max);
            }
        }
    }
}
