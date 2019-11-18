using System;

namespace _6_var
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.UInt64.MaxValue);
            string str = "qweqwoasdzxco";
            for(int i=0;i<str.Length;i++)
            {
                if(str[i]=='o')
                {
                    Console.WriteLine(i+1);
                    break;
                }
            }
            char[][] jagged = new char[3][] { new char[1] { '1' }, new char[2] { '1', '2' }, new char[3] { '1', '2', '3' } };
            for (int i = 0; i< jagged.Length;i++)
            {
                Console.WriteLine(jagged[i]);
            }
            Button b1 = new Button(2, 3, "blue");
            Button b2 = new Button(2, 5, "red");
            if (b1.Equals(b2)) Console.WriteLine("EEEEEE");
            else Console.WriteLine("Baaaadddd");
            Student pasha = new Student();
            ((IThink)pasha).Future();
            ((IDo)pasha).Future();
        }

        sealed class Button
        {
            public int height;
            public int width;
            public static string color;
            public int Height
            {
                get => height;
                set => height = value;
            }
            public int Width
            {
                get => width;
                set => width = value;
            }
            public static string Color
            {
                get => color;
                set => color = value;
            }
            public Button(int height, int width, string color)
            {
                this.height = height;
                this.width = width;
                Button.color = color;
            }
            public override bool Equals(object obj)
            {
                Button b = obj as Button;
                if (b == null) return false;
                if (b.height == height && b.width == width ) return true;
                else return false;
            }
        }
        public interface IThink
        {
            void Future();
        }
        public interface IDo
        {
            void Future();
        }
        public class Student:IThink,IDo
        {
            void IThink.Future()
            {
                Console.WriteLine("..........................");
            }
            void IDo.Future()
            {
                Console.WriteLine("123123123123123123123");
            }
        }
    }
}
