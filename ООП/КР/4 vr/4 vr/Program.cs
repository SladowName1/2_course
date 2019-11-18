using System;

namespace _4_vr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ushort.MaxValue);
            Date d1 = new Date("1", "2", "3");
            Date d2 = new Date("1", "2", "3");
            if (d1.Equals(d2)) Console.WriteLine("EEEEEEEEE");
        }
    }
}

public class Date
{
    public string day {set; get; }
    public string month { set; get; }
    public string year { get; }
    public Date(string day, string month, string year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }
    public override bool Equals(object obj)
    {
        Date d = obj as Date;
        if (d == null) return false;
        if (d.month == month && d.day == day && d.year == year) return true;
        else return false;
    }

}

public interface IGood
{
    void plus();
}
public interface IBad
{
    void minus();
}

public abstract class People { }
public class Student : People { }
public class Prepod : People { }