using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;
namespace Labs_13
{
    class Program
    {
        static void Main(string[] args)
        {
            //GVPLog.GVPDiskInfo.Method();
            //Console.WriteLine("///////////////////////////////////");
            //GVPLog.GVPFileInfo.Method();
            //Console.WriteLine("///////////////////////////////////");
            //GVPLog.GVPDirInfo.Method();
            //Console.WriteLine("///////////////////////////////////");
            //GVPLog.GVPFileManager.Method();
            string[] str = File.ReadAllLines("E:\\2_course\\ООП\\observer.txt");
            string s = Console.ReadLine();
            int counter = 0;
            StreamWriter sw = new StreamWriter("E:\\2_course\\ООП\\observer.txt", false, Encoding.Default);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Contains(s))
                {
                    Console.WriteLine(str[i - 2] + str[i - 1] + str[i]);
                    sw.WriteLine(str[i - 2]);
                    sw.WriteLine(str[i - 1]);
                    sw.WriteLine(str[i]);
                }
                counter++;
            }
            sw.Close();
            Console.WriteLine("Counter of records" + counter);

        }
    }
}


