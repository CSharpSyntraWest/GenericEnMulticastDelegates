using System;

namespace Oef2_GenericDelegate
{
    public delegate bool MijnGenericDelegate<T>(T param1, T param2);
    class Program
    {
        static bool IsGelijk(int getal1, int getal2)
        {
            return getal1 == getal2;
        }
        static bool IsGelijk(double getal1, double getal2)
        {
            return getal1 == getal2;
        }
        static bool IsGelijk<T>(T param1, T param2)
        {
            return param1.Equals(param2);
        }
        static void Main(string[] args)
        {
            MijnGenericDelegate<int> del_int = IsGelijk;
            Console.WriteLine($"IsGelijk(5,5)= " + del_int(5, 5));
            Console.WriteLine($"IsGelijk(5,6)= " + del_int(5, 6));

            MijnGenericDelegate<double> del_double = IsGelijk;
            Console.WriteLine($"IsGelijk(5.5,5.5)= " + del_double(5.5, 5.5));
            Console.WriteLine($"IsGelijk(5.5,6.5)= " + del_double(5.5, 6.5));

            MijnGenericDelegate<string> del_string = IsGelijk;
            Console.WriteLine($"IsGelijk('Jos','Jos')= " + del_string("Jos", "Jos"));
            Console.WriteLine($"IsGelijk('Jos','Jan')= " + del_string("Jos", "Jan"));
            Console.ReadKey();
        }
    }
}
