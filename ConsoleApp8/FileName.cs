using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace ConsoleApp8
{
    public class MoneyWork
    {
        private class Money
        {
            private uint _rubles;
            private byte _kopeks;
           public uint Rubles
            {
                get { return _rubles; }
                set { if (value > 0) { _rubles = value; } }

            }
           public byte Kopeks
            {
                get { return _kopeks; }
                set { if (value > 0) { _kopeks = value; } }
            }
            public Money(uint Rubles, byte Kopeks)
            {
                _rubles = Rubles;
                _kopeks = Kopeks;
            }
            public static Money operator +(Money m, byte Kopeks)
            {
                return m + Kopeks; 
            }
        }
        
       
    }
}
