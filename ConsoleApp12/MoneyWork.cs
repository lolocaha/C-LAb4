public class MoneyWork
{

    public class Money
    {
        private uint _rubles;
        private byte _kopeks;

        public uint Rubles
        {
            get { return _rubles; }
            set { _rubles = value; }
        }

        public byte Kopeks
        {
            get { return _kopeks; }
            set
            {
                if (value >= 100) throw
                new ArgumentException("Копеек должно быть меньше 100");
                _kopeks = value;
            }
        }

        public Money(uint rubles, byte kopeks)
        {
            Rubles = rubles;
            Kopeks = kopeks;
        }

        private ulong ToKopeks()
        {
            return (ulong)_rubles * 100 + _kopeks;
        }

        private static Money FromKopeks(ulong total)
        {
            return new Money((uint)(total / 100), (byte)(total % 100));
        }

        public static Money operator +(Money m, uint kopeks)
        {
            return FromKopeks(m.ToKopeks() + kopeks);
        }

        public static Money operator +(uint kopeks, Money m)
        {
            return FromKopeks(m.ToKopeks() + kopeks);
        }

        public static Money operator -(Money m, uint kopeks)
        {
            ulong total = m.ToKopeks();
            if (kopeks > total) throw
            new InvalidOperationException
            ("Сумма не может быть отрицательной");
            return FromKopeks(total - kopeks);
        }

        public static Money operator -(uint kopeks, Money m)
        {
            ulong total = m.ToKopeks();
            if (total > kopeks) throw new
             InvalidOperationException
             ("Сумма не может быть отрицательной");
            return FromKopeks(kopeks - total);
        }
        public static Money operator ++(Money m)
        {
            return FromKopeks(m.ToKopeks() + 1);
        }
        public static Money operator --(Money m)
        {
            ulong total = m.ToKopeks();
            if (total == 0) throw new
            InvalidOperationException
            ("Сумма не может быть отрицательной");
            return FromKopeks(total - 1);
        }

        public static explicit operator uint(Money m)
        {
            return m._rubles;
        }

        public static implicit operator double(Money m)
        {
            return m._kopeks / 100.0;
        }

        public override string ToString()
        {
            return _rubles + " руб. " + _kopeks + " коп.";
        }
    }


}