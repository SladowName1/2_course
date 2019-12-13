using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Labs_12
{
    class Program
    {
        static void Main(string[] args)
        {
            User admin = new User();
            Type t = admin.GetType();
            Type t1 = Type.GetType("System.Int32");
            Type t2 = typeof(Pointer);
            Console.WriteLine($"{t}------{t1}------{t2}");
        }
    }
    class User
    {

    }
    public class Reflector
    {
        static public void Input(object obj)
        {
            string WP = @"D:\text.txt";

            StreamWriter sw = new StreamWriter(WP, true, System.Text.Encoding.Default);

            Type m = obj.GetType();
            MemberInfo[] members = m.GetMembers();
            foreach(MemberInfo item in members)
            {
                sw.WriteLine($"{item.DeclaringType}  {item.MemberType}  {item.Name}");

            }
            sw.Close();
        }
        static public void Output()
        { }
        static public void GetInfoAboutPolya()
        { }
        static public void GetInfoAboutInterface()
        { }
        static public void OutputMethod()
        { }
        static public void CallSomeMethod()
        { }

    }
}
