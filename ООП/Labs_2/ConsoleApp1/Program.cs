using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ex1-1
            int a = 5;
            double b = 5.2;
            string str = "abc";
            object a1 = a;
            object b1 = b;
            object str1 = str;
            int a2 = (int)a1;
            double b2 = (double)b1;
            string str2 = (string)str1;
            Console.WriteLine($"{a} {a1} {a2}");
            Console.WriteLine($"{b} {b1} {b2}");
            Console.WriteLine($"{str} {str1} {str2}");
            //////////////////////////////////////////////////////////////////////////
            //ex1-2
            int igroup = 1;
            double dgroup = (int)igroup;
            byte bgroup = (byte)igroup;
            long lgroup = igroup;
            //////////////////////////////////////////////////////////////////////////////
            //ex1-3
            string name = "Pasha";
            string format = String.Format("My name is ") + name;
            Console.WriteLine(format);
            Console.WriteLine("My name is "+name);
            /////////////////////////////////////////////////////////////////////////
            //ex1-4
            Console.WriteLine(a1.ToString());
            Console.WriteLine(str2.GetHashCode());
            Console.WriteLine(bgroup.GetType());
            bool aEa1 = a.Equals(a1);
            Console.WriteLine(aEa1);
            /////////////////////////////////////////////////////////////////////
            string ex1_5="ex1_5 ";
            string ex1_5_2="ex1_5_2";
            string Insert_ex1_5 = "good ex";
            Console.WriteLine(string.Compare(ex1_5,ex1_5_2));
            bool ex5 = ex1_5_2.Contains(ex1_5);
            Console.WriteLine("'{0}' this string in this '{1}'? {2}",ex1_5, ex1_5_2, ex5);
            ex1_5_2 = ex1_5_2.Substring(2);
            Console.WriteLine(ex1_5_2);
            ex1_5 = ex1_5.Insert(6,Insert_ex1_5);
            Console.WriteLine(ex1_5);
            ex1_5 = ex1_5.Replace("good", "bad");
            Console.WriteLine(ex1_5);
            ///////////////////////////
            //ex1_6
            string ex1_6_1 = "";
            string ex1_6_2 = null;
            Console.WriteLine("string ex1_6_1 {0}", Test(ex1_6_1));
            Console.WriteLine("string ex1_6_2 {0}", Test(ex1_6_2));
            String Test(string s)
            {
                if (String.IsNullOrEmpty(s))
                    return "is null or empty";
                else
                    return String.Format("(\"{0}\" is neither null or empty", s);
            }
            //////////////////////////////////////////////////
            //ex1_7
            var ex1_7 = 4;
            //ex1_7 = (double)5.2;
            /////////////////////////
            // ex1_8
            int? ex1_8 = 4;
            Console.WriteLine(ex1_8);
            Console.WriteLine(ex1_8.Value);
            int ex1_8_2 = (int)ex1_8;
            Console.WriteLine(ex1_8_2);
            ////////////////////////////////////////////////////////
            //ex2_1

            var tuple = ex2_1_func();
            Console.WriteLine(tuple);
            Console.WriteLine(tuple.Item2);
            static (int,int) ex2_1_func()
            {
                var ex2_1 = (1, 2);
                return ex2_1;
            }
            ///////////////////////////////
            var tuple_ex2_2 = (a: 3, b: 5, _:8);
            Console.WriteLine(tuple_ex2_2.Item2);
            Console.WriteLine(tuple_ex2_2.Item3);
            Console.WriteLine(tuple_ex2_2);
            /////////////////////////////////
            int ex2_3_1_1 = func_ex2_3();
            int ex2_3_1_2 = func_ex2_3_1();
            Console.WriteLine(ex2_3_1_1+2);
            Console.WriteLine(ex2_3_1_2 + 2);
            int func_ex2_3()
            {
                checked
                {
                    int ex2_3 = int.MaxValue;
                    return ex2_3;
                }
            }
            int func_ex2_3_1()
            {
                unchecked
                {
                    int ex2_3_1 = int.MaxValue;
                    return ex2_3_1;
                }
            }
        }
    }
}
