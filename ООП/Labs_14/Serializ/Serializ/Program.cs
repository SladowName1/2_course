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

namespace Serializ
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
            Console.WriteLine("----------------------------------------------------------------");

            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\expirement.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, test1);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\expirement.dat", FileMode.OpenOrCreate))
            {
                Test newTest = (Test)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"{newTest.Topic}   {newTest.Numbers}");
            }
            Console.WriteLine("----------------------------------------------------------------");

            SoapFormatter formatter2 = new SoapFormatter();
            using (FileStream fs = new FileStream("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\expirement2.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, test2);
                Console.WriteLine("Объект сериализован");
            }

            using (FileStream fs = new FileStream("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\expirement2.dat", FileMode.OpenOrCreate))
            {
                Test newTest2 = (Test)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"{newTest2.Topic}     {newTest2.Numbers}");
            }
            Console.WriteLine("----------------------------------------------------------------");

            DataContractJsonSerializer formatter3 = new DataContractJsonSerializer(typeof(Test));
            using (FileStream fs = new FileStream("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\expirement3.json", FileMode.OpenOrCreate))
            {
                formatter3.WriteObject(fs, test3);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\expirement3.json", FileMode.OpenOrCreate))
            {
                Test newTest3 = (Test)formatter3.ReadObject(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"{newTest3.Topic}   {newTest3.Numbers}");
            }
            Console.WriteLine("----------------------------------------------------------------");

            XmlSerializer formatter4 = new XmlSerializer(typeof(Test));
            using (FileStream fs = new FileStream("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\expirement4.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, test4);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\expirement4.xml", FileMode.OpenOrCreate))
            {
                Test newTest4= (Test)formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"{newTest4.Topic}    {newTest4.Numbers}");
            }
            Console.WriteLine("----------------------------------------------------------------");

            BinaryFormatter formatter5 = new BinaryFormatter();
            using (FileStream fs = new FileStream("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\expirements1.dat", FileMode.OpenOrCreate))
            {
                formatter5.Serialize(fs, test);
                Console.WriteLine("Массив объектов сериализован");
            }
            using (FileStream fs = new FileStream("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\expirements1.dat", FileMode.OpenOrCreate))
            {
                Test[] newTests = (Test[])formatter.Deserialize(fs);
                Console.WriteLine("Массив объектов десериализован");
                foreach (Test item in newTests)
                {
                    Console.WriteLine($"{item.Topic}    {item.Numbers}");
                }
            }
            Console.WriteLine("----------------------------------------------------------------");

            Console.WriteLine("Первый xml запрос (выбор названия):");
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\XMLFile1.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlNodeList childnodes1 = xRoot.SelectNodes("test");
            foreach (XmlNode n in childnodes1)
            {
                Console.WriteLine(n.SelectSingleNode("@topic").Value);
            }

            Console.WriteLine("Второй xml запрос (получаем сложность):");
            XmlNodeList childnodes2 = xRoot.SelectNodes("//test/diffuclt");
            foreach (XmlNode n in childnodes2)
            {
                Console.WriteLine(n.InnerText);
            }
            Console.WriteLine("Третий запрос (конкретный возраст):");
            XmlNode childnode3 = xRoot.SelectSingleNode("test[counter='18']");
            if (childnode3 != null)
            {
                Console.WriteLine(childnode3.OuterXml);
            }
            Console.WriteLine("----------------------------------------------------------------");

            XDocument document = new XDocument();
            XElement root = new XElement("countries");
            XElement country1 = new XElement("country");
            root.Add(country1);
            XAttribute number1 = new XAttribute("number", "1");
            country1.Add(number1);
            XElement CounryName1 = new XElement("name", "Belarus");
            country1.Add(CounryName1);
            XElement square1 = new XElement("square", "207 595 км²");
            country1.Add(square1);
            XElement population1 = new XElement("population", "9.508 million");
            country1.Add(population1);

            XElement country2 = new XElement("country");
            root.Add(country2);
            XAttribute number2 = new XAttribute("number", "2");
            country2.Add(number2);
            XElement CounryName2 = new XElement("name", "Russia");
            country2.Add(CounryName2);
            XElement square2 = new XElement("square", "17 100 000 км²");
            country2.Add(square2);
            XElement population2 = new XElement("population", "144,5 million");
            country2.Add(population2);
            document.Add(root);
            document.Save("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\Countries.xml");
            Console.WriteLine("Документ создан при помощи  LINQ to XML");
            Console.WriteLine("----------------------------------------------------------------");

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("E:\\2 курс\\2_course\\ООП\\Labs_14\\Serializ\\Countries.xml");
            XmlElement Root = xdoc.DocumentElement;
            Console.WriteLine("Первый xml запрос (выбор имён):");
            XmlNodeList childnodes4 = Root.SelectNodes("country");
            foreach (XmlNode n in childnodes4)
            {
                Console.WriteLine(n.SelectSingleNode("name").InnerText);
            }
            Console.WriteLine("Второй xml запрос (получаем площадь):");
            XmlNodeList childnodes5 = Root.SelectNodes("//country/square");
            foreach (XmlNode n in childnodes5)
            {
                Console.WriteLine(n.InnerText);
            }
            Console.WriteLine("Третий запрос (нужное население):");
            XmlNode childnode6 = Root.SelectSingleNode("country[population='144,5 million']");
            if (childnode6 != null)
            {
                Console.WriteLine(childnode6.OuterXml);
            }
        }
    }
}

