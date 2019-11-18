using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _5_var
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "1232345";
            People ui1 = new People();
            if (ui1 is ICan)
                Console.WriteLine("People поддерживает интерфейс ICan");
            else
                Console.WriteLine(":(");

            People a = new People();
            Orator.Checker(a);

        }
    }
    class Person
    {
        public string Name { get; set; }
    }
    interface ICan
    {
        void speak();
    }
    class People : ICan
    {
        public void speak()
        {
            Console.WriteLine("SPEAK");
        }
    }
    static class Orator
    {
        public static void Checker(People x)
        {
            Console.WriteLine(x is ICan);
        }
    }

}
