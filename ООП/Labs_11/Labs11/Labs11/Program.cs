using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Labs11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] month ={"january","febuary","march","april","may",
                "june","jule","august","september","october","november","december"};
            var linq1 = from t in month
                        where t.Length == 4
                        select t;
            foreach(var t in linq1)
            {
                Console.Write(t+"; ");
            }
            Console.WriteLine();
            Console.WriteLine("////////////////////////////////////////////");
            //var linq2 = from t in month
            //            where t.IndexOf()
            //            select t;

            var linq3 = from t in month
                       orderby t
                        select t;
            foreach(var t in linq3)
            {
                Console.Write(t + "; ");
            }
            Console.WriteLine();
            Console.WriteLine("////////////////////////////////////////////");
            var linq4 = from t in month
                        where t.Contains('u')
                        where t.Length >= 4
                        select t;
            foreach(var t in linq4)
            {
                Console.Write(t + "; ");
            }
            Console.WriteLine();
            Console.WriteLine("////////////////////////////////////////////");
            List<Student> student = new List<Student>()
            {
                 new Student{specialty="ISiT", group=1,age=19,surname="Grudinsky", name="Pasha" } ,
                 new Student{specialty="ISiT", group=1,age= 20,surname= "Denisuk",name="Vanya"},
                 new Student{specialty= "DEW",group= 3,age= 18,surname= "Yackunovich",name= "Sanya"},
                 new Student{specialty= "POIT",group= 3, age= 19,surname= "Tsedrik",name= "Egor"},
                 new Student{specialty="MOB",group= 6,age=17,surname= "Korh",name= "Denis"},
                  new Student{specialty="asd",group= 36,age=127,surname= "ASD",name= "Denis"},
            };

            var linq_speciality = from t in student
                                  where t.specialty=="ISiT"
                                  select t;
            foreach(var t in linq_speciality)
            {
                Console.WriteLine(t + "; ");
            }
            Console.WriteLine("////////////////////////////////////////////");

            var linq_group = from t in student
                             where t.@group == 3
                             select t;


            foreach (var t in linq_group)
            {
                Console.WriteLine(t + "; ");
            }
            Console.WriteLine("////////////////////////////////////////////");

            int younger = student.Min(t => t.age);
            var linq_younger = from t in student
                               where t.age == younger
                               select t;
            foreach(var t in linq_younger)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("////////////////////////////////////////////");

            var linq_group_and_surname = from t in student
                                         where t.@group == 3
                                         orderby t.surname
                                         select t;

            foreach (var t in linq_group_and_surname)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("////////////////////////////////////////////");

            //IEnumerable<Student> first = student.First(t => t.name.Equals("Denis"));
            //IEnumerable<Student> second = student.Where(t => t.name.Equals("Denis"));
            //var linq_first_surname = from t in student
            //                         where t.name.Equals("Denis")
            //                         select t;

            //foreach (var t in linq_first_surname)
            //{
            //    Console.WriteLine(t);
            //}
            //Console.WriteLine("////////////////////////////////////////////");
            bool anyStudent = student.Any(t => t.name.Equals("a"));
            var linq_my = from t in student
                          where t.age > 17
                          orderby t.name
                          select t;
            foreach(var t in linq_my)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("////////////////////////////////////////////");

        }
        public class Student
        {
           public  string specialty { get; set; }
           public  int group { get; set; }
           public int age { get; set; }
           public string surname { get; set; }
           public string name { get; set; }

            public override string ToString()
            {
                return $" {name}  {surname}  {age}  {specialty} {group}";
            }
        }
        
    }
}