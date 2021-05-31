using System;

namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational first = new Rational(-1,2);
            Rational second = new Rational(2,20);
            Rational test;
            Console.WriteLine( "x1 = " + first.ToString());
            Console.WriteLine("x2 = " + second.ToString() + "\n");
            test = first + second;
            Console.WriteLine($"a + b = {test.GetDouble()}");
            test = first - second;
            Console.WriteLine($"a - b = {test.GetDouble()}");
            test = first * second;
            Console.WriteLine($"a * b = {test.GetDouble()}");
            test = first / second;
            Console.WriteLine($"a / b = {test.GetDouble()}");
            int a = -3;
            test = first ^ a;
            Console.WriteLine($"a ^ {a} = {test.GetDouble()}");
            test = Rational.Abs(test);
            Console.WriteLine($"|a| = {test.GetDouble()}");
            Console.WriteLine();
            Console.WriteLine($" a > b : {first > second}");
            Console.WriteLine($" a < b : {first < second}");
            Console.WriteLine($" a >= b : {first >= second}");
            Console.WriteLine($" a <= b : {first <= second}");
            Console.WriteLine($" a == b : {first == second}");
            Console.WriteLine($" a != b : {first != second}");
            Console.WriteLine();
           
            try
            {
                Rational third = new Rational(1,0);
            }
            catch (EnteringExceptions e)
            {
                Console.Write(e.Message);
                Console.WriteLine();
            }
            
            Console.WriteLine($"To Int32 -> {first.ToInt32(null)}");
            Console.WriteLine($"To Boolean -> {first.ToBoolean(null)}");
            Console.WriteLine($"To Decimal -> {first.ToDecimal(null)}");
            Console.WriteLine();

            Console.WriteLine(first.ToString("standart"));
            Console.WriteLine(first.ToString("Denumerator1"));
            Console.WriteLine(first.ToString("IntegerPart"));
            Console.WriteLine(first.ToString("Integer0"));
            Console.WriteLine(first.ToString("Decimal"));
            try
            {
                first.ToString("A");
            }
            catch (EnteringExceptions e)
            {
                Console.WriteLine(e.Message);
            }

            double x = 55.420;
            test = 14 + x;
            Console.WriteLine(test.ToString("standart"));
            Console.WriteLine(test.ToString("Decimal"));
        }
    }
}