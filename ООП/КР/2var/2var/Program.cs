using System;

namespace _2var
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(double.MaxValue);
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            Console.WriteLine(str1+str2);
            int[][] jagged = new int[2][] { new int[3] { 1, 2, 3 }, new int[5] { 1, 2, 3, 4, 5 } };
            foreach(int[] a in jagged)
            {
                foreach(int b in a)
                    {
                    Console.Write(b);
                }
                Console.WriteLine();
            }
        }
        IStudy pasha = new Prepod();
        pasha.Study();
    }
    public interface IStudy
    {
        void Study();
    }

    public abstract class Student : IStudy
    {
        public virtual void Study()
        {
            Console.WriteLine("Учусь");
        }
    }
    public class Prepod : Student, IStudy
    {
        void IStudy.Study()
        {
            Console.WriteLine("Учу");
        }
        public override void Study()
        {
            base.Study();
        }
    }


}

