using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Text.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test1 = new Test("asd", 123);
            Test test2 = new Test("asdz", 12);
            Test test3 = new Test("asdd", 12);
            Test test4 = new Test("asbd", 1233);
            Test[] test = new Test[] { test1, test2, test3, test4 };
            string json = JsonSerializer.Serialize<Test>(test1);
            Console.WriteLine(json);
            Test restoredTest = JsonSerializer.Deserialize<Test>(json);
            Console.WriteLine(restoredTest.Topic);

            XmlSerializer formatter = new XmlSerializer(typeof(Test));
            using (FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, test2);
            }
            using (FileStream fs = new FileStream("test.xml", FileMode.OpenOrCreate))
            {
                Test newTest=(Test)formatter.Deserialize(fs);
                Console.WriteLine($"{newTest.Topic}");
            }
            Console.ReadLine();

            SoapFormatter soapFormatter = new SoapFormatter();
            using(FileStream fs=new FileStream("tests.soap",FileMode.OpenOrCreate))
            {
                soapFormatter.Serialize(fs, test3);
            }
            using(FileStream fs=new FileStream("tests.soap", FileMode.OpenOrCreate))
            {
                Test NewTest = (Test)soapFormatter.Deserialize(fs);

                    Console.WriteLine(NewTest.Topic);

            }
            Console.ReadLine();
        }
    }
}
