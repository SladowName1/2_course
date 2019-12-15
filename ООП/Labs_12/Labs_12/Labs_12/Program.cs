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
            Exams exam = new Exams("Biology",32);
            Test test = new Test("Phisik", 15);
            FinalExam finalExam = new FinalExam("PE", 15, 13);
            Exams exam2 = new Exams("Info", 13);

            Reflector.Input(exam);
            Reflector.Output(exam);
            Reflector.GetInfoAboutPolya(finalExam);
            Reflector.GetInfoAboutInterface(finalExam);
            Reflector.OutputMethod(test);

            Reflector.CallSomeMethod("Reflection.TestParams","showParams");
        }
    }
    public class Reflector
    {
        static public void Input(object obj)
        {
            string WP = @"E:\2_course\ООП\Labs_12\text.txt";

            StreamWriter sw = new StreamWriter(WP, false, System.Text.Encoding.Default);

            Type m = obj.GetType();
            MemberInfo[] members = m.GetMembers();
            foreach(MemberInfo item in members)
            {
                sw.WriteLine($"{item.DeclaringType}  {item.MemberType}  {item.Name}");

            }
            sw.Close();
        }
        static public void Output(object obj)
        {
            Type m = obj.GetType();
            MethodInfo[] public_method = m.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
            Console.WriteLine("Onlu public method");
            foreach(MethodInfo item in public_method)
            {
                Console.WriteLine(item.ReflectedType.Name+"--"+item.Name);
            }
        }
        static public void GetInfoAboutPolya(object obj)
        {
            Type m = obj.GetType();
            Console.WriteLine("Fields: ");
            FieldInfo[] fields = m.GetFields();
            foreach(FieldInfo item in fields)
            {
                Console.WriteLine(item.FieldType+"--"+item.Name);
            }
            Console.WriteLine("Properties: ");
            PropertyInfo[] properties = m.GetProperties();
            foreach(PropertyInfo item in properties)
            {
                Console.WriteLine(item.PropertyType+"--"+item.Name);
            }
        }
        static public void GetInfoAboutInterface(object obj)
        {
            Type m = obj.GetType();
            Console.WriteLine("Implemented Interfaces: ");
            foreach(Type item in m.GetInterfaces())
            {
                Console.WriteLine(item.Name);
            }
        }
        static public void OutputMethod(object obj)
        {
            Console.WriteLine("Enter type name for parameter: ");
            string findType = Console.ReadLine();
            Type m = obj.GetType();
            MethodInfo[] methods = m.GetMethods();
            foreach(MethodInfo iten in methods)
            {
                ParameterInfo[] p = iten.GetParameters();
                foreach(ParameterInfo item in p)
                {
                    if(item.ParameterType.Name==findType)
                    {
                        Console.WriteLine("Method: "+iten.ReturnType.Name+"--"+iten.Name);
                    }
                }
            }
        }
        static public void CallSomeMethod(string Class, string MethodName)
        {
            StreamReader reader = new StreamReader(@"E:\2_course\ООП\Labs_12\text.txt", Encoding.Default);
            string param_1, param_2, param_3;
            param_1 = reader.ReadLine();
            param_2 = reader.ReadLine();
            param_3 = reader.ReadLine();
            reader.Close();

            Type m = Type.GetType(Class, false);
            object st = Activator.CreateInstance(m, null);
            MethodInfo method=m.GetMethod(MethodName);
            method.Invoke(st, new object[] { param_1, char.Parse(param_2), int.Parse(param_3) });
        }

    }
}
