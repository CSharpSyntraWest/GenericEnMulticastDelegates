using System;

namespace MultiCastDelegate
{
    public delegate int MyMultiCastDelegate<T>(T param);
    class Program
    {
        static int PrintString(string tekst)
        {
            Console.WriteLine($"Printstring met param='{tekst}'");
            return 1;
        }

        static int PrintStringLengte(string text)
        {
            Console.WriteLine($"PrinStringLengte met param='{text}' : lengte {text.Length}");
            return 2;
        }
        static void Main(string[] args)
        {
            MyMultiCastDelegate<string> del_multicast = PrintString;
            del_multicast += PrintStringLengte;

            int result = del_multicast("een string");
            Console.WriteLine("Terugkeerwaarde via multicast delegate: " + result);
            Console.ReadKey();
        }
    }
}
