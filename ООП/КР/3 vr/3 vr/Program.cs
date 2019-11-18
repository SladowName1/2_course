using System;

namespace _3_vr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(decimal.MaxValue);
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            Console.WriteLine(str1==str2);
            string[] a =new[] { "asd", "asd", "xzc" };
            Student pasha = new Student();
            pasha.coding();
            ((IDo)pasha).coding();
        }
    }
}
public class Month
{
    string[] month = new[] {"January","February","March","April","May",
            "June","July","September","October","November","December" };

}

public interface IDo
{
    void coding();
}

public abstract class Programmer
{
    public void coding() 
    {
        Console.WriteLine("codding");
    }
}

public class Student:Programmer,IDo
{
    void IDo.coding()
    {
        Console.WriteLine("dont cod");
    }
}
