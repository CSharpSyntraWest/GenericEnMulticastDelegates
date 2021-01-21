using System;

namespace DemoGenericDelegate
{
    public delegate T MijnGenericDelegate<T>(T param1, T param2);
    class Program
    {
        static int Min(int getal1, int getal2)
        {
            return Math.Min(getal1, getal2);
        }
        static int Max(int getal1, int getal2)
        {
            return Math.Max(getal1, getal2);
        }
        static double Deling(double getal1, double getal2)
        {
            return getal1 / getal2;
        }
        static void Main(string[] args)
        {
            MijnGenericDelegate<int> del_gen = Min;//new MijnGenericDelegate<int>(Min);
            int minWaarde =  del_gen(5, 6);
            Console.WriteLine("Minimum waarde = " + minWaarde);
            del_gen = Max;
            Console.WriteLine("Max Waarde is= " + del_gen(5, 6));
            //del_gen = Deling; verkeerde type (T is geen int bij del_gen)
            MijnGenericDelegate<double> del_gen2 = Deling;
            Console.WriteLine("Deling van 10 door 3 = " + del_gen2(10.0, 3.0));
            //del_gen = new MijnGenericDelegate<double>(Deling); werkt niet, want del_gen oorspronkelijk als MijnGenericDelegate<int> 

            Console.ReadKey();
        }
    }
}
