using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Labs_13
{
    public delegate void userActions(string str);
    class GVPLog
    {
        private const string path = "E:\\2_course\\ООП\\observer.txt";
        public static event userActions Observe = (str) =>  //событие для остлеживания действий пользователя

        {

            try
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {

                    sw.WriteLine(str);
                    sw.WriteLine($"Дата использования:");

                    sw.WriteLine(DateTime.Now);


                }
            }


            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        };

        public  class GVPDiskInfo
        {
            static public void Method()
            {
                var Drivers = DriveInfo.GetDrives();
                foreach (var d in Drivers)
                {
                    Console.WriteLine(d.Name);
                    if (!d.IsReady)
                    {
                        Console.WriteLine("This disk don't ready");
                        continue;
                    }
                    Console.WriteLine(d.DriveFormat);
                    Console.WriteLine(d.TotalSize);
                    Console.WriteLine(d.TotalFreeSpace);
                    Console.WriteLine(d.VolumeLabel);

                }
                Observe("Пользователь воспользовался методом DiskInfo");
            }
        }
       public class GVPFileInfo
        {
            static public void Method()
            {
                string path = @"E:\labi_OIT\4лаба\2z.html";
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    Console.WriteLine(file.DirectoryName);
                    Console.WriteLine(file.Name + "   " + file.Length + "  " + file.Extension);
                    Console.WriteLine(file.CreationTime);
                }
                Observe("Пользователь воспользовался методом FileInfo");
            }
        }
       public class GVPDirInfo
        {
            static public void Method()
            {
                string path = @"E:\2_course";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                string[] dirs = Directory.GetDirectories(path);
                int counter_dir = 0;
                if (dirInfo.Exists)
                {
                    foreach (string s in dirs)
                    {
                        counter_dir++;
                    }
                    Console.WriteLine("Counter Dir " + counter_dir);
                    string[] files = Directory.GetFiles(path);
                    int counter_files = 0;
                    foreach (string s in files)
                    {
                        counter_files++;
                    }
                    Console.WriteLine("Counter fils " + counter_files);
                    Console.WriteLine(dirInfo.CreationTime);
                    Console.WriteLine(dirInfo.Parent);
                }
                Observe("Пользователь воспользовался методом DirInfo");
            }
        }

       public class GVPFileManager
        {
            static public void Method()
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                string path1 = @"E:\";
                string path = @"E:\2_course\OOP\GVPInspect";
                string path2 = @"E:\2_course\OOP\GVPInspect\gvpdirinfo.txt";

                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                    dirInfo.Create();

                StreamWriter sw = new StreamWriter(path2, false, System.Text.Encoding.Default);
                string[] dirs = Directory.GetDirectories(path1);
                foreach (string s in dirs)
                {

                    sw.WriteLine(s);

                }
                sw.WriteLine("///////////////////////////");
                string[] files = Directory.GetFiles(path1);
                foreach (string s in files)
                {
                    sw.WriteLine(s);
                }
                sw.Close();

                string path3 = @"E:\2_course\OOP\GVPInspect\gvpdirinfo2.txt";
                FileInfo file = new FileInfo(path2);
                file.CopyTo(path3, true);
                file.Delete();
                string path4 = @"E:\2_course\OOP\GVPFiles";
                DirectoryInfo dir2 = new DirectoryInfo(path4);
                if (!dir2.Exists)
                    dir2.Create();
                string path5 = @"E:\2_course\Игиг";
                DirectoryInfo dir3 = new DirectoryInfo(path5);
                foreach (FileInfo itme in dir3.GetFiles())
                {
                    if (itme.Name.Contains(".cdw"))
                    {
                        itme.CopyTo($"E:\\2_course\\OOP\\GVPFiles\\{itme.Name}");
                    }
                }
                string path9 = @"E:\2_course\OOP\GVPFiles";
                DirectoryInfo dir4 = new DirectoryInfo(path9);
                dir4.MoveTo("E:\\2_course\\OOP\\GVPInspect\\GVPFiles");
                string path_to_zip = "E:\\2_course\\OOP\\GVPInspect\\GVPFiles\\compress.gz";
                DirectoryInfo zipfile = new DirectoryInfo("E:\\2_course\\OOP\\GVPInspect\\GVPFiles");
                foreach (FileInfo item in zipfile.GetFiles())
                {



                    // поток для чтения исходного файла
                    using (FileStream sourceStream = new FileStream(item.FullName, FileMode.OpenOrCreate))
                    {
                        // поток для записи сжатого файла
                        using (FileStream targetStream = File.Create(path_to_zip))
                        {
                            // поток архивации
                            using (GZipStream gz = new GZipStream(targetStream, CompressionMode.Compress))
                            {
                                sourceStream.CopyTo(gz);
                                Console.WriteLine("Сжатие файла {0} завершено. Исходный размер: {1}  сжатый размер: {2}.",
                            item.FullName, sourceStream.Length.ToString(), targetStream.Length.ToString());
                            }
                        }
                    }


                }
                DirectoryInfo directory = new DirectoryInfo(path1);
                foreach (FileInfo item in directory.GetFiles())
                {
                    if (file.Name.Contains(".cdw"))
                    {



                        using (FileStream sourceStream = new FileStream(path_to_zip, FileMode.OpenOrCreate))
                        {
                            // поток для записи восстановленного файла
                            using (FileStream targetStream = File.Create($"{path3}\\{item.Name}"))
                            {
                                // поток разархивации
                                using (GZipStream decompressionStream = new GZipStream(sourceStream, CompressionMode.Decompress))
                                {
                                    decompressionStream.CopyTo(targetStream);
                                    Console.WriteLine("Восстановлен файл: {0}", path_to_zip);
                                }
                            }
                        }
                    }
                }
                Observe("Пользователь воспользовался методом FileManager");
            }
        }
    }
}
