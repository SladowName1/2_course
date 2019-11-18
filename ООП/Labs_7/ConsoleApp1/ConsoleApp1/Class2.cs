using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    static partial class Contreller
    {
        public static void Find_By_Number_Of_Exams(List<Exams> exams)
        {
            int count = 0;
            int str = Convert.ToInt32(Console.ReadLine());
            foreach (Exams item in exams)
            {
                if (str == item.Number_of_exams)
                {
                    Console.WriteLine($"Names {item.Topic}    Diffuclt {item.Numbers}   Counter   {item.Number_of_exams}");
                    count++;
                }
            }
            if (count == 0)
                Console.WriteLine("Такого экзамена нету в списке");
        }
        public static void Find_By_Topic(List<Exams> exams)
        {
            int count = 0;
            string str = Console.ReadLine();
            foreach (Exams item in exams)
            {
                if (str == item.Topic)
                {
                    Console.WriteLine($"Название: {item.Topic}   Сложность: {item.Numbers}");
                    count++;
                }
            }
            if (count == 0)
                Console.WriteLine("Такого экзамена нету в списке");
        }
    }
}
