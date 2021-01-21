using System;
using System.Diagnostics.CodeAnalysis;

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
        class Student : IEquatable<Student>
        { 
            public string VoorNaam { get; set; }
            public string FamilieNaam { get; set; }
            public DateTime GeboorteDatum { get; set; }
            public bool Equals(Student other)
            {
                return GeboorteDatum == other.GeboorteDatum
                    && FamilieNaam.ToLower() == other.FamilieNaam.ToLower()
                    && this.VoorNaam.ToLower()==other.VoorNaam.ToLower();
            }
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
            //Extra demo
            MijnGenericDelegate<Student> del_stud = IsGelijk;
            Student student1 = new Student() { VoorNaam = "Jos", FamilieNaam = "De Klos",GeboorteDatum= new DateTime(1990,1,1) };
            Student student2 = new Student() { VoorNaam = "Jan" ,FamilieNaam="Jansens", GeboorteDatum= new DateTime(1990, 1, 1) };
            Student student3 = new Student() { VoorNaam = "Jos", FamilieNaam = "De Klos", GeboorteDatum = new DateTime(1990, 1, 1) };
            Console.WriteLine($"IsGelijk(student1,student1)= " + del_stud(student1,student1));
            Console.WriteLine($"IsGelijk(student1,student2)= " + del_stud(student1, student2));
            // Console.WriteLine($"IsGelijk(student1,student3)= " + del_stud(student1, student3));
            //Demo Bug enkel bij Delegates
            //Dit werkt wel op gewoonlijke manier:
            Console.WriteLine($"IsGelijk(student1,student3) zonder delegate = " + student1.Equals(student3));
            //!!!Opgelet BUG met delegate:
           // Console.WriteLine($"IsGelijk(student1,student3) via delegate = " + del_stud(student1, student3));
            Console.ReadKey();
        }
    }
}
