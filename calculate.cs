using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Calc
{
    public class Rational : IComparable<Rational>, IFormattable, IConvertible
    {
        protected long numerator;
        protected long denumerator;

        public Rational(long numerator, long denumerator)
        {
            Numerator = numerator;
            Denumerator = denumerator;
        }

        public Rational(long numerator)
        {
            Numerator = numerator;
            Denumerator = 1;
        }

        public long Numerator
        {
            get => numerator;
            set
            {
                numerator = value;
                if (denumerator != 0 && numerator != 0)
                {
                    long gcd = GCD(numerator, denumerator);
                    numerator /= gcd;
                    denumerator /= gcd;
                }
            }
        }

        public long Denumerator
        {
            get => denumerator;
            set
            {
                denumerator = value;
                if (denumerator == 0)
                {
                    throw new EnteringExceptions("Denumerator cannot be a null , try again laser brain");
                }
                if (denumerator != 0 && numerator != 0)
                {
                    long gcd = Rational.GCD(numerator, denumerator);
                    numerator /= gcd;
                    denumerator /= gcd;
                }
            }
        }
        
        public static long GCD(long a, long b) 
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a > 0 && b > 0) 
            {
                if (a > b)
                {
                    a %= b;
                } 
                else 
                {
                    b %= a;
                }
            }
            return a + b;
        }

        public double GetDouble()
        {
            return (double) Numerator / Denumerator;
        }
        
        public static Rational operator +(Rational first, Rational second)
        {
            long lcm = first.Denumerator * second.Denumerator / Rational.GCD(first.Denumerator, second.Denumerator);
            long x1 = first.Numerator * lcm / first.Denumerator;
            long x2 = second.Numerator * lcm / second.Denumerator;
            return new Rational(x1 + x2, lcm);
        }
        
        public static Rational operator -( Rational second)
        {
            return second * new Rational(-1);
        }

        public static Rational operator -(Rational first, Rational second)
        {
            return first + (-second);
        }

        public static Rational operator *(Rational first, Rational second)
        {
            return new Rational(first.Numerator * second.Numerator , first.Numerator * second.Numerator);
        }

        public static Rational operator /(Rational first, Rational second)
        {
            return new Rational(first.Numerator * second.Denumerator,second.Numerator * first.Denumerator);
        }
        
        public int CompareTo(Rational other)
        {
            long lcm = this.Denumerator * other.Denumerator / Rational.GCD(this.Denumerator, other.Denumerator);
            long firstNewNumerator = this.Numerator * lcm / this.Denumerator;
            long secondNewNumerator = other.Numerator * lcm / other.Denumerator;
            if (firstNewNumerator > secondNewNumerator) return 1;
            else if (firstNewNumerator < secondNewNumerator) return -1;
            else return 0;
        }

        public static bool operator ==(Rational first, Rational second)
        {
            return first.CompareTo(second) == 0;
        }

        public static bool operator !=(Rational first, Rational second)
        {
            return first.CompareTo(second) != 0;
        }
        
        public static bool operator >=(Rational first, Rational second)
        {
            return first.CompareTo(second) >= 0;
        }

        public static bool operator <=(Rational first, Rational second)
        {
            return first.CompareTo(second) <= 0;
        }
        
        public static bool operator >(Rational first, Rational second)
        {
            return first.CompareTo(second)  == 1;
        }
        
        public static bool operator <(Rational first, Rational second)
        {
            return first.CompareTo(second) == -1;
        }

        public double ToDouble(IFormatProvider provider)
        {
            return GetDouble();
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(GetDouble());
        }
        
        public static explicit operator int (Rational number)
        {
            return number.ToInt32(null);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(GetDouble());
        }

        public static explicit operator short(Rational number)
        {
            return number.ToInt16(null);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(GetDouble());
        }

        public static explicit operator long(Rational number)
        {
            return number.ToInt64(null);
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(GetDouble());
        }

        public static explicit operator bool(Rational number)
        {
            return number.ToBoolean(null);
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(GetDouble());
        }

        public static explicit operator char(Rational number)
        {
            return number.ToChar(null);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(GetDouble());
        }

        public static explicit operator SByte(Rational number)
        {
            return number.ToSByte(null);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(GetDouble());
        }

        public static explicit operator Byte(Rational number)
        {
            return number.ToByte(null);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(GetDouble());
        }

        public static explicit operator UInt16(Rational number)
        {
            return number.ToUInt16(null);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(GetDouble());
        }
        
        public static explicit operator UInt32(Rational number)
        {
            return number.ToUInt32(null);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(GetDouble());
        }
        
        public static explicit operator UInt64(Rational number)
        {
            return number.ToUInt64(null);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(GetDouble());
        }

        public static explicit operator Single(Rational number)
        {
            return number.ToSingle(null);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(GetDouble());
        }

        public static explicit operator decimal(Rational number)
        {
            return number.ToDecimal(null);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(GetDouble());
        }

        public static explicit operator DateTime(Rational number)
        {
            return number.ToDateTime(null);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(GetDouble(), conversionType);
        }
        
        public override bool Equals(Object obj)
        {
            Rational number = obj as Rational;
            if (number == null) return false;
            return this.Numerator == number.Numerator && this.Denumerator == number.Denumerator;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool TryParse(string input, out Rational number )
        {
            number = null;
            Regex patternRegular = new Regex(@"^(\d*)[/](\d*)$"); // 17/20
            Regex patternDotComma = new Regex(@"^(\d*)[,.](\d*)$"); // 17,19 == 17 + 19/100
            Regex patternDen1 = new Regex(@"\d*$"); // 17 == 17/1
            if (patternRegular.IsMatch(input) != false)
            {
                char[] separator = new char [1] {'/'}; 
                string[] buffer = input.Split(separator);
                long numerator = long.Parse(buffer[0]);
                long denumerator = long.Parse(buffer[1]);
                number = new Rational(numerator,denumerator);
                return true;
            }
            else if (patternDotComma.IsMatch(input) != false)
            {
                char[] separator = new char [2] {'.',','}; 
                string[] buffer = input.Split(separator);
                long numerator = long.Parse(buffer[0]);
                long denumerator = long.Parse(buffer[1]);
                number = new Rational(numerator,denumerator);
                return true;
            }
            else if (patternDen1.IsMatch(input) != false)
            {
                long numerator = long.Parse(input);
                number = new Rational(numerator);
                return true;
            }
            else return false;
        }

        public static Rational Parse(string input)
        {
            Rational value;
            if (TryParse(input, out value)) return value;
            throw new ParseExceptions("Your string has wrong format, try again laser brain");
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return ToString(format);
        }

        public override string ToString()
        {
            return ToString("Denumerator1");
        }

        public string ToString(string format)
        {
            if (format == null)
            {
                format = "Denumerator1";
            }
            switch (format)
            {
                case "standart":
                    return string.Concat(Numerator, "/", Denumerator);
                case "Denumerator1":
                    if (Denumerator == 1) return Numerator.ToString();
                    return ToString("standart");
                case "IntegerPart":
                    string res = string.Concat(Math.Abs(Numerator / Denumerator), " ", Math.Abs(Numerator % Denumerator), "/", Denumerator);
                    if (Numerator < 0) res = "-" + res;
                    return res;
                case "Integer0":
                    if (Numerator / Denumerator == 0 || Numerator % Denumerator == 0) return ToString("Denumerator1");
                    else return ToString("IntegerPart");
                case "Decimal":
                    return ((decimal)Numerator / Denumerator).ToString();
                default:
                    throw new EnteringExceptions("Wrong format");
            }
        }
        
        public static Rational operator ^(Rational first, int degree) // My Pow
        {
            if (degree == 0) return new Rational(1);
            else if (degree > 0)
            {
                long numerator = 1;
                long denumerator = 1;

                while (degree != 0)
                {
                    numerator *= first.Numerator;
                    denumerator *= first.Denumerator;
                    degree--;
                }
                return new Rational(numerator,denumerator);
            }
            else
            {
                degree *= -1;
                long numerator = 1;
                long denumerator = 1;

                while (degree != 0)
                {
                    numerator *= first.Numerator;
                    denumerator *= first.Denumerator;
                    degree--;
                }
                return new Rational(numerator,denumerator);
            }
        }
        
        public static Rational Abs(Rational number)
        {
            return new Rational(Math.Abs(number.Numerator), number.Denumerator);
        }

        public static implicit operator Rational(int x)
        {
            return new Rational(x);
        }

        public static implicit operator Rational(double x)
        {
            double fract = x - (int) x;
            string buffer = fract.ToString();
            long denumerator = 1;
            int count = 0;
            for (int i = 0; i < buffer.Length - 1; i++)
            {
                if (buffer[i] == '0')
                {
                    if (buffer[i + 1] == '0')
                    {
                        break;
                    }
                    else count++;
                }
                else count++;
            }
            
            while (count != 0)
            {
                denumerator *= 10;
                count--;
            }
            long numerator = (long) x * denumerator + (long)(fract * denumerator);
            return new Rational(numerator, denumerator);
        }
    }
}