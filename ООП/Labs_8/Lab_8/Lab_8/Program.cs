using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab_8
{
    class Program
    {
        interface IGeneric<Type>
        {
            void Add(Type item);
            Type Delete(int item);
            void Check();
        }
        public class CollectionType<Type>:IGeneric<Type> where Type:class
        {
            string writePath = @"E:\labs\OOP\Labs_8\lab_8.txt";
            public List<Type> stroka = new List<Type>();
            public void Add(Type item)
            {
                stroka.Add(item);
            }
            public Type Delete(int item)
            {
                Type value = stroka[item];
                stroka.RemoveAt(item);
                return value;
            }
            public void Check()
            {
                int count = 0;
                foreach(Type item in stroka)
                {
                    count++;
                    Console.WriteLine($"Элемент списка под номером {count}\n Type:{item.GetType()}");
                }
            }
            int counter = 0;
            public void WriteToFile()
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath,false,System.Text.Encoding.Default))
                    {
                        foreach(Type t in stroka)
                        {
                            sw.WriteLine(t);

                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            public void WriteToFile1()
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        foreach (Type t in stroka)
                        {

                            sw.WriteLine(t);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            public void ReadFromFile()
            {
                try
                {
                    using(StreamReader sr=new StreamReader(writePath))
                    {
                        counter++;
                        Console.Write($"Элемент под номером {counter}");
                        Console.WriteLine(sr.ReadToEnd());
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public class StandartTypes<Type1, Type2, Type3> where Type1:struct where Type2:struct where Type3:struct
        {
            Type1 A { get; set; }
            Type2 B { get; set; }
            Type3 C { get; set; }
            public StandartTypes(Type1 A, Type2 B, Type3 C)
            {
                this.A = A;
                this.B = B;
                this.C = C;
            }

            public void ShowTypes()
            {
                Console.WriteLine($"Первый тип {A.GetType()} его значение {A}");
                Console.WriteLine($"Второй тип {B.GetType()} его значение {B}");
                Console.WriteLine($"Третий тип {C.GetType()} его значение {C}");
            }
        }
        static void Main(string[] args)
        {
            //char c = 'b';
            //string str11 = "zabbbsdazasdzxcvza";
            //Console.WriteLine(str11.HowManyZ());
            //Console.WriteLine("строка увеличилась :" + str11.Add());
            //int i = str11.CharCount(c);
            //Console.WriteLine($"сколько символов b содержит строка {i}");



            String _string1 = new String();
            Console.WriteLine("Введите строку");
            _string1.Stroka = Console.ReadLine();
            Console.WriteLine("Введите вторую строку");
            String _string2 = new String();
            _string2.Stroka = Console.ReadLine();
            Console.WriteLine("Введите третью строку");
            String _string3 = new String();
            _string3.Stroka = Console.ReadLine();
            Console.WriteLine("Введите четвертую строку");
            String _string4 = new String();
            _string4.Stroka = Console.ReadLine();
            Console.WriteLine("///////////////////////////////////////////");

            CollectionType<String> ColletionFor8Lab = new CollectionType<String>();
            ColletionFor8Lab.Add(_string1);
            ColletionFor8Lab.Add(_string2);
            ColletionFor8Lab.Add(_string3);
            ColletionFor8Lab.Add(_string4);

            ColletionFor8Lab.Check();
            ColletionFor8Lab.WriteToFile();
            Console.WriteLine("//////////////////////////////////////////");
            Console.WriteLine("Чтение из файла");
            ColletionFor8Lab.ReadFromFile();
            Console.WriteLine("//////////////////////////////////////////");
            bool exeption = false;
            try
            {
                String give_for_me = ColletionFor8Lab.Delete(3);
                Console.WriteLine($"Строка которую извлекли {give_for_me.Stroka}");
                ColletionFor8Lab.Check();
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message+"\n" +ex.Source);
                exeption = true;
            }
            finally
            {
                if(exeption)
                    Console.WriteLine("Исключение было обработано");
                else
                    Console.WriteLine("Исключение не произошло или не было обработана");
            }


            Console.WriteLine("/////////////////////////////////////////////");
            ColletionFor8Lab.WriteToFile1();
            Console.WriteLine("//////////////////////////////////////////");
            Console.WriteLine("Чтение из файла");
            ColletionFor8Lab.ReadFromFile();

            bool exeption2 = false;
            try
            {
                StandartTypes<int, double, byte> myTypes = new StandartTypes<int, double, byte>(110,1.2,4);
                myTypes.ShowTypes();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message+"\n"+ex.Source);
                exeption2 = true;
            }
            finally
            {
                if (exeption)
                    Console.WriteLine("Исключение было обработано");
                else
                    Console.WriteLine("Исключение не произошло или не было обработана");
            }

            //if (_string1 > _string2)
            //    Console.WriteLine("первая строка больше второй");
            //else Console.WriteLine("Первая строка меньше второй либо они одинакового размера");


            //Console.WriteLine("----------------------------------------------------------");
            //if (_string1.stroka == _string2.stroka)
            //    console.writeline("строки идентичны");
            //else
            //    console.writeline("строки не идентичны");
            //console.writeline("------------------------------------------------------------");
            //console.writeline("введите символ для занесения его в строку");
            //string a;
            //a = console.readline();
            //int b = int.parse(a);
            //string result = _string1 + b;
            //console.writeline(result.stroka);
            //console.writeline("----------------------------------------------------------------");
            //string minus = -_string1;
            //console.writeline(minus.stroka);
            //console.writeline("---------------------------------------------------------");
            //console.writeline("введите символ");
            //char symbol = (char)console.read();
            //string zamena = _string2 * symbol;
            //console.writeline(zamena.stroka);
            //console.writeline("------------------------------------------------");
            //console.writeline("есть служебные знаки?");
            //if (_string1)
            //    console.writeline("есть");
            //else
            //    console.writeline("нету служебных");
            //console.writeline("--------------------------------------------------------");
            //console.writeline("происходит удаление знаков припенания");
            //console.writeline(_string2.delete());
            //console.writeline("----------------------------------------------------");
            //string.date date = new string.date(18, 10, 2019);
            //date.getdate();
            //console.writeline("----------------------------------------------------------");
        }
    }


    public class String
    {
        public string stroka;
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
    public static class StaticClass
    {
        static public int Summa(String s1, String s2)
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
            for (int i = 0; i < str.Length; i++)
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