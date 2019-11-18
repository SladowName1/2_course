using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(char.MaxValue);
            int a = Convert.ToInt32(Console.ReadLine());
            int[,,] b = { {  { }, { } }, { { }, { } } , { { }, { } }, { { }, { } }  };
        }
    }
}
public class Time
{
    private string hours;
    private string minutest;
    private string seconds;
    public string Hours
    {
        get => hours;
        set => hours = value;

    }
    public string Minutes
    {
        get => minutest;
        set => minutest = value;

    }
    public string Second
    {
        get => seconds;
        set => seconds = value;

    }
    public Time(string hours, string minutes, string second)
    {
        this.hours = hours;
        this.minutest = minutes;
        this.seconds = second;
    }
    enum Afternoon
    {
        AM, PM
    }
    public override string ToString()
    {
        return base.ToString();
    }
    House asd = new House("Паша");
    House fchome = new House("Pavel");
    fchome.Run();
}

public interface IRun
{
    void Run();
}
public class Mammal
{
    public string name;
    public Mammal(string name)
    {
        this.name = name;
    }
}

class House:Mammal,IRun
{
    public House(string name):base(name)
    {
    }
    public void Run()
    {
        Console.WriteLine(name.Length);
    }
}