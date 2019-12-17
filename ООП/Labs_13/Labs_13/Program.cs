using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Labs_13
{
    class Program
    {
        static void Main(string[] args)
        {
            var Drivers = DriveInfo.GetDrives();
            foreach(var d in Drivers)
            {
                Console.WriteLine(d.Name);
                Console.WriteLine(d.DriveFormat);
                Console.WriteLine(d.TotalSize);
                Console.WriteLine(d.TotalFreeSpace);
            }
          
        }
    }
}
