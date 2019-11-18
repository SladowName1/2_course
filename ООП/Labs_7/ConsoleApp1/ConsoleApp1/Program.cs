using System;
using System.Diagnostics;
using ConsoleApp1;

namespace Lab_6
{
   

    public interface IExpirement
    {
        void counter();
        void difficult();
        void balls();
        void days();

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
        protected int id;
        public int Numbers
        {
            get
            {
                return numbers;
            }
            set
            {
                if(value<4)
                {
                    throw new WrongNumbersValue("Недопустимое значени для задания количества экзаменов", value);
                }
                else numbers = value;
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

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value < 0)
                {
                    throw new WrongIdValue("Недопустимое значение для id", value);
                }
                else id = value;
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
        public abstract void days();
    }


    public class Test : Question, Ialive
    {
        public Test(string topic, int numbers, int numbers_of_exams,int id)
        {
            if (topic.Length <= 4)
            {
                throw new IsNotTopic("Недопустистимое знчение для топика", topic);
            }
            else this.topic = topic;
            this.numbers = numbers;
            this.number_of_exams = numbers_of_exams;
            this.id = id;
        }
        public override void days()
        {
            string words = Console.ReadLine();
            Debug.Assert(words != "", "Должны быть дни");
            Console.WriteLine(words);
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
        public Exams(string topic, int numbers, int numbers_of_exams,int id)
        {
            this.topic = topic;
            this.numbers = numbers;
            this.number_of_exams = numbers_of_exams;
            this.id = id;
        }
        public override void difficult()
        {
            Console.WriteLine("Diffucult this exams");
        }
        public override void days()
        {
            Console.WriteLine("Monday");
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
        public FinalExam(string topic, int numbers, int numbers_of_exams,int id) : base(topic, numbers, numbers_of_exams,id)
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
    class Program
    {
        static void Main(string[] args)
        
        {
          
                string[] str = new string[5];
                try
                {
                    str[4] = "anything";
                    Console.WriteLine("It's OK");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("IndexOutOfRangeException");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception");
                }


            try
            {

                Console.WriteLine("////////////////////////////////////////////////");

                try
                {
                    Test tes1 = new Test("La", 4, 5, 6);
                }
                catch (IsNotTopic ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }

                Console.WriteLine("////////////////////////////////////////////////");

                try
                {
                    Exams exam = new Exams("Biology", 6, 4, 3);
                    exam.Numbers = 3;
                }

                catch (WrongNumbersValue ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }

                Console.WriteLine("////////////////////////////////////////////////");

                try
                {
                    FinalExam final_exam = new FinalExam("Logistik", 5, 6, 11);
                    final_exam.Id = -3;
                }

                catch (WrongIdValue ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }

                Console.WriteLine("////////////////////////////////////////////////");

                Test test2 = new Test("Mathematic", 4, 5, 11);
                Exams exam2 = new Exams("Fisikz", 6, 4, 0);
                FinalExam final_exam2 = new FinalExam("Blogs", 5, 6, 32);
                Question[] questions = new Question[] { test2, exam2, final_exam2 };

                try
                {
                    Console.WriteLine(questions[4].Numbers);
                }

                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }

                Console.WriteLine("////////////////////////////////////////////////");

                try
                {
                    object obj = exam2.Topic;
                    int name = (int)obj;
                }

                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }

                Console.WriteLine("////////////////////////////////////////////////");

                try
                {
                    double count = test2.Numbers / exam2.Id;
                }

                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
                }

                Console.WriteLine("////////////////////////////////////////////////");

                test2.days();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}\n{ex.Source}\n{ex.StackTrace}");
            }
            finally
            {
                Console.WriteLine("Блок finally");
            }
        }
    }
}
