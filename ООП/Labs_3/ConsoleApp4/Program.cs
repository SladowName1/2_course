using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_lab
{

    public partial class Food
    {
        partial void NewStudent();

        public void Study()
        {
            Console.WriteLine("My name Pasha");
            NewStudent();
        }
    }

    public partial class Food
    {
        partial void NewStudent()
        {
            Console.WriteLine("I want to study");
        }
    }

    class Student
    {
        private int id;
        public string name;
        public string producer;
        public string surname;
        public string lastname;
        public int day;
        public int month;
        public int year;
        public string adres;
        public int number;
        public string faculety;
        public static int course;
        public int gruppa;
        private float value_;
        static readonly int ID2;
        private const string data = "11.04";





        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (id < 1000)
                    Console.WriteLine("Id should be bigger than 1000");
                else
                    id = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }

        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                month = value;
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
        public string Adres
        {
            get
            {
                return adres;
            }
            set
            {
                adres = value;
            }
        }
        public int Number
        {
            set
            {
                int a = value;
                number = a++;
            }
            get
            {
                return number;
            }
        }
        public static int Course
        {
            set
            {
                int a = 1;
                Course = a++;
            }
            get
            {
                return Course;
            }
        }
        public string Faculty
        {
            get
            {
                return faculety;
            }
            set
            {
                faculety = value;
            }
        }
        public int Gruppa
        {
            get
            {
                return gruppa;
            }
            set
            {
                gruppa = value;
            }
        }
        static Student()
        {
            var rand = new Random();
            ID2 = rand.Next(1000, 9999);
        }

        public Student()
        {
            id = 5735;
            name = "Petya";
            lastname = "Павлович";
            surname = "Павлович";
            adres = "Сухарево";
            day = 1;
            month = 3;
            year = 2000;
            number = +1234;
            faculety = "FIT";
            gruppa = 1;
        }

        public Student(int n)
        {
            id = n;
            name = "Grokda";
            lastname = "Павлович";
            surname = "Павлович";
            adres = "Кишенева";
            day = 12;
            month = 6;
            year = 2001;
            number = +123134;
            faculety = "PIM";
            gruppa = 2;
        }


        public Student(ref int n, string a, string e, string f, int g, int h, int j, string b, int c, string d,int x)
        {
            id = n;
            name = a;
            surname = e;
            lastname = f;
            day = g;
            month = h;
            year = j;
            adres = b;
            number = c;
            faculety = d;
            gruppa = x;

        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Id:{id}  Name:{name}" +
                $" Surname: {surname}  Lastname: {lastname}" +
                $" Birthday: {day}.{month}.{year}" +
                $" Adres: {adres}" +
                $" Faculety: {faculety}" +
                $" ID2:{ID2}" +
                $" Course: {course}"+
                $" Gruppa: {gruppa}");
        }


        public static string GetInfo_2()
        {
            return about;
        }

        public static string About
        {
            get
            {
                return about;
            }
        }

        private static string about = "this is you";
    }

    class Student_2 : Student
    {
        public string Kalor { get; set; }
        public string name { get; set; }
        public Student_2(string name, string lastname)
        {
            Kalor = Kalor;
        }
        public override void GetInfo()
        {
            Console.WriteLine($" Name:{name}" +
                $" Lastname: {lastname}");
        }
        public Student_2(string n, string c, string k)
        {
            name = n;
            lastname = c;
            Kalor = k;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Student karl = new Student();
            karl.GetInfo();

            karl.Id = 105672;
            karl.Name = "karl";
            karl.Lastname = "голубев";
            karl.Surname = "васильевич";
            karl.Adres = "Сухарево";
            karl.Number = 43112;
            karl.Faculty = "LES";
            karl.GetInfo();

            Student meat = new Student();

            Student fruits = new Student(1723);

            int a = 384;
            int z = 17324;
            Student vasya = new Student(ref a, "vasya", "григорьев", "петрович", 1, 3, 15, "Малиновка", 1134, "PIM",2);

            meat.GetInfo();
            fruits.GetInfo();
            vasya.GetInfo();

            Console.WriteLine(Student.About);

            Food orange = new Food();
            orange.Study();

            Student[] arr = new Student[5];
            arr[0] = new Student(ref a, "Паша", "Денисюк", "Павлович", 30, 4, 2006, "Петровщина", 2234, "FIT",3);
            arr[1] = new Student(ref a, "Петя", "ГРудинский", "Павлович", 21, 6, 1996, "Октяборьская", 2534, "PIM",1);
            arr[2] = new Student(ref a, "Алёша", "Абрака", "Павлович", 23, 5, 2008, "революционная", 3123, "LES",2);
            arr[3] = new Student(ref a, "Ваня", "Цедрик", "Павлович", 4, 1, 2006, "Горецкого", 4523, "FIT",1);
            arr[4] = new Student(ref a, "Алексей", "Оленцевич", "Павлович", 11, 9, 2001, "Пушкина", 21234, "FIT",1);
            for (int i = 0; i < arr.Length; i++)
                arr[i].GetInfo();

            string nameOfStudent;
            Console.WriteLine("Enter Faculety");
            nameOfStudent = Console.ReadLine();
            int grupa;
            string str;
            str = Console.ReadLine();
            grupa = Convert.ToInt32(str);
            Console.WriteLine(grupa);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Faculty==nameOfStudent)
                {
                    Console.WriteLine($"This guys study in {nameOfStudent}");
                    arr[i].GetInfo();
                }
            }
            Console.WriteLine("Nothing else");

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Gruppa==grupa)
                {
                    Console.WriteLine($"This is grupa {grupa}");
                    arr[i].GetInfo();
                }
            }
            Console.WriteLine("Nothing else");

            var name = new { Name = "karl", id = 25674 };
            Console.WriteLine(name.Name);

            Student_2 p2 = new Student_2("pasha", "Valis.e", "LES");
            p2.GetInfo();

            Console.ReadKey();
        }
    }
}
