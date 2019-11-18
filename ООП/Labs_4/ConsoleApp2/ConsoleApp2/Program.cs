using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            char c = 'b';
            string str11 = "zabbbsdazasdzxcvza";
            Console.WriteLine(str11.HowManyZ());
            Console.WriteLine("строка увеличилась :"+str11.Add());
            int i = str11.CharCount(c);
            Console.WriteLine($"сколько символов b содержит строка {i}");



            String _string1 = new String();
            Console.WriteLine("Введите строку");
            _string1.Stroka= Console.ReadLine();
            Console.WriteLine("Введите вторую строку");
            String _string2 = new String();
            _string2.Stroka = Console.ReadLine();
            if (_string1 > _string2)
                Console.WriteLine("первая строка больше второй");
            else Console.WriteLine("Первая строка меньше второй либо они одинакового размера");


            Console.WriteLine("----------------------------------------------------------");
            if (_string1.Stroka == _string2.Stroka)
                Console.WriteLine("Строки идентичны");
            else
                Console.WriteLine("Строки не идентичны");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Введите символ для занесения его в строку");
            string a ;
            a = Console.ReadLine();
            int b=int.Parse(a);
            String result = _string1 + b;
            Console.WriteLine(result.Stroka);
            Console.WriteLine("----------------------------------------------------------------");
            String minus = -_string1;
            Console.WriteLine(minus.Stroka);
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Введите символ");
            char symbol = (char)Console.Read();
            String zamena = _string2 * symbol;
            Console.WriteLine(zamena.Stroka);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Есть служебные знаки?");
            if(_string1)
                Console.WriteLine("Есть");
            else
                Console.WriteLine("нету служебных");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Происходит удаление знаков припенания");
            Console.WriteLine(_string2.delete());
            Console.WriteLine("----------------------------------------------------");
            String.Date date = new String.Date(18,10,2019);
            date.getDate();
            Console.WriteLine("----------------------------------------------------------");
        }
    }


    public class String
    {
        public string stroka;
        Owner owner = new Owner(111, "Vasya", "bus");
        public class Date
        {
            private int day;
            private int month;
            private int year;
            public Date(int day, int month, int year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }
            public void getDate()
            {
                Console.WriteLine($"Year:{year}  Month:{month}    Day:{day}");
            }
        }
        public string Stroka
        {
            get
            {
                return stroka;
            }
            set
            {
                stroka = value;
            }
        }
        public string this[string str]
        {
            set
            {
                stroka = value;
            }
            get
            {
                return stroka;
            }
        }

        public static bool operator <(String s1, String s2)
        {
            if (s1.Stroka.Length < s2.Stroka.Length)
                return true;
            else if (s1.Stroka.Length == s2.Stroka.Length)
                return false;
            else
                return false;
        }
        public static bool operator >(String s1, String s2)
        {
            if (s1.Stroka.Length > s2.Stroka.Length)
                return true;
            else if (s1.Stroka.Length == s2.Stroka.Length)
                return false;
            else
                return false;
        }
        public static String operator +(String s1, int numbers)
        {
            int a = s1.Stroka.Length;
            string str = s1.Stroka;
            string b = Convert.ToString(numbers);
            string str2;
            str2 = str.Insert(a, b);
            return new String { Stroka = str2 };
        }
        public static String operator -(String s1)
        {
            string str = s1.Stroka;
            string str2 = str.TrimEnd(str[str.Length - 1]);
            str = str2;
            return new String { Stroka = str };
        }
        public static String operator *(String s1, char symbol)
        {
            string str = s1.Stroka;
            for (int i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], symbol);
            }
            return new String { Stroka = str };
        }
        public static bool operator true(String s1)
        {
            return s1.Stroka.Contains('#');
        }
        public static bool operator false(String s1)
        {
            return s1.Stroka.Contains('9');
        }
    }
        public static class Delete
        {
            public static string delete(this String _string)
            {
            string str = _string.Stroka;
            str = str.Trim(new char[] { ',', '.', '!', '?' });
            return str;
            }
        }
    
    public class Owner
    {
        int id;
        string name;
        string org;
        public Owner(int id, string name, string org)
        {
            this.id = id;
            this.name = name;
            this.org = org;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Org
        {
            get { return org; }
            set { org = value; }
        }
        public void GetInfo()
        {
            Console.WriteLine($"ID: {id}   Name:{name}  Organisation:{org}");
        }
    }
    public static class StaticClass
    {
        static public int Summa(String s1,String s2)
        {
            return Math.Abs(s1.Stroka.Length + s2.Stroka.Length);
        }
        static public int Difference(String s1, String s2)
        {
            return Math.Abs(s1.Stroka.Length - s2.Stroka.Length);
        }
        static public int Show(String s1)
        {
            return s1.Stroka.Length;
        }
    }
    public static class StatisticOperation
    {
        public static int HowManyZ(this string str)
        {
            int z = 0;
            for(int i=0; i<str.Length;i++)
            {
                if (str[i] == 'z')
                    z++;
            }
            return z;
        }
        public static string Add(this string str)
        {
            str = str + Console.ReadLine();
            return str;
        }
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }
    }
}