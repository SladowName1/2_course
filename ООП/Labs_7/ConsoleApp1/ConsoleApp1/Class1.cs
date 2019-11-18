using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    static class Session
    {
        public static List<Exams> All_exams = new List<Exams>();
        public static List<Exams> all_exmas { get; set; }
        public static void Add(Exams exams)
        {
            All_exams.Add(exams);
            Console.WriteLine("В список добавлен {0}", exams.Topic); ;
        }

        public static Exams Remove(Exams exams)
        {
            foreach (Exams item in All_exams)
            {
                if (exams == item)
                {
                    All_exams.Remove(exams);
                    return exams;
                }
            }
            Console.WriteLine("Такого экзамена нету в списке");
            return null;
        }
        public static void ShowList()
        {
            Console.WriteLine("Полный список экзаменов");
            foreach (Exams exams in All_exams)
            {
                Console.WriteLine($"Название:{exams.Topic}   Сложность:{exams.Numbers}  Количество:{exams.Number_of_exams}");
            }
        }
        public struct First_Exmas
        {
            public string exams;
            public enum Examss : long
            {
                first = 1, second, third
            }
        }

    }
    static partial class Contreller
    {
        public static int CounterOfExams(List<Exams> exams)
        {
            int counter = 0;
            for (int i = 0; i < exams.Count; i++)
            {
                counter++;
            }
            Console.WriteLine($"Общее количество экзаменов  {counter}");
            return counter;
        }
    }
}
