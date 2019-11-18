using System;
using System.Diagnostics;
using Lab_6;

namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Exams exams1 = new Exams("Biology", 4, 5);
                FinalExam finalexam1 = new FinalExam("Logistik", 6, 5);

                Exams exams2 = new Exams("Biology", 4, 3);
                FinalExam finalexam2 = new FinalExam("Logistik", 6, 5);
                Session.Add(exams1);
                Session.Add(exams2);
                Session.Add(finalexam1);
                Session.Add(finalexam2);

                Console.WriteLine("----------------------------------------------");
                Session.ShowList();
                Console.WriteLine("----------------------------------------------");
                int counter = Contreller.CounterOfExams(Session.All_exams);
                Console.WriteLine("Counter of exams{0}", counter);
                Console.WriteLine("----------------------------------------------");
                Contreller.Find_By_Number_Of_Exams(Session.All_exams);
                Console.WriteLine("----------------------------------------------");
                Contreller.Find_By_Topic(Session.All_exams);
                Console.WriteLine("----------------------------------------------");

                Session.First_Exmas first_exams;
                Console.WriteLine("Введите какой экзамен будет первым");
                first_exams.exams = Console.ReadLine();
                Console.WriteLine("Сколько всего будет экзаменов");
                switch (int.Parse(Console.ReadLine()))
                {
                    case (int)Session.First_Exmas.Examss.first:
                        Console.WriteLine("будет один экзамен");
                        break;
                    case (int)Session.First_Exmas.Examss.second:
                        Console.WriteLine("будет два экзамен");
                        break;
                    case (int)Session.First_Exmas.Examss.third:
                        Console.WriteLine("будет три экзамен");
                        break;
                    default:
                        Console.WriteLine("не может быть столько экзаменов");
                        break;
                }
            }
            catch 
            {

            }
        }
    }

    public interface IExpirement
    {
        void counter();
        void difficult();
        void balls();

    }


    interface Ialive
    {
        void Clone();
    }


    public abstract class Question : IExpirement
    {
        protected int numbers;
        protected string topic;
        protected int number_of_exams;
        public int Numbers
        {
            get
            {
                return numbers;
            }
            set
            {
                numbers = value;
            }
        }
        public string Topic
        {
            get
            {
                return topic;
            }
            set
            {
                topic = value;
            }
        }
        public int Number_of_exams
        {
            get
            {
                return number_of_exams; 
            }
            set 
            {
                number_of_exams = value; 
            }
        }
        public override string ToString()
        {
            Console.WriteLine(Topic + " " + Numbers);
            return " type " + base.ToString();
        }
        virtual public bool TestPassed(int correct_question)
        {
            return true;
        }
        public abstract void difficult();
        public abstract void balls();
        public abstract void counter();
        public abstract void Clone();
    }


    public class Test : Question, Ialive
    {
        public Test(string topic, int numbers, int numbers_of_exams)
        {
            this.topic = topic;
            this.numbers = numbers;
            this.number_of_exams = numbers_of_exams;
        }
        public override void difficult()
        {
            Console.WriteLine("Diffucult this test");
        }
        public override void balls()
        {
            Console.WriteLine("Balls for this test");
        }
        public override void counter()
        {
            Console.WriteLine("Numbers of question on this test");
        }
        public override void Clone()
        {
            Console.WriteLine("This method from abstract class");
        }
        void Ialive.Clone()
        {
            Console.WriteLine("interfaces method");
        }
        public override bool TestPassed(int correct_question)
        {
            if (correct_question != null && correct_question != 0)
            {
                numbers = correct_question;
                return true;
            }
            else
                return false;
        }
    }


    public class Exams : Question, Ialive
    {
        public Exams(string topic, int numbers, int numbers_of_exams)
        {
            this.topic = topic;
            this.numbers = numbers;
            this.number_of_exams = numbers_of_exams;
        }
        public override void difficult()
        {
            Console.WriteLine("Diffucult this exams");
        }
        public override void balls()
        {
            Console.WriteLine("Balls for this exams");
        }
        public override void counter()
        {
            Console.WriteLine("Numbers of question on this exams");
        }
        public override void Clone()
        {
            Console.WriteLine("This method from abstract class");
        }
        void Ialive.Clone()
        {
            Console.WriteLine("interfaces method");
        }
        public override bool TestPassed(int correct_question)
        {
            if (correct_question != null && correct_question != 0)
            {
                numbers = correct_question;
                return true;
            }
            else
                return false;
        }
    }


    sealed public class FinalExam : Exams
    {
        public FinalExam(string topic, int numbers, int numbers_of_exams) : base(topic, numbers, numbers_of_exams)
        {
        }
        public bool canReady()
        {
            if (number_of_exams < 5)
                return true;
            else
                return false;
        }
    }


    public class ForObject : Object
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            return true;
        }
        public string Topic { get; set; }
        int cNumbers;
        public override int GetHashCode()
        {
            int hash = 250;
            hash = string.IsNullOrEmpty(Topic) ? 0 : Topic.GetHashCode();
            hash = (hash * 10) + cNumbers.GetHashCode();
            return hash;
        }
    }


    public class Printer
    {
        public void IAmPrinting(Question question)
        {
            Console.WriteLine(question.ToString());
        }
    } 
}
