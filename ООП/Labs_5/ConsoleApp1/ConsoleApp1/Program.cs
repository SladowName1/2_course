using System;

namespace ConsoleApp1
{
    interface Expirement
    {
        void counter();
        void difficult();
        void balls();
    }


    interface Ialive
    {
        void Clone();
    }


    public abstract class Question : Expirement
    {
        protected int numbers;
        protected string topic;
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
        public Test(string topic, int numbers)
        {
            this.topic = topic;
            this.numbers = numbers;
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
        public Exams(string topic, int numbers)
        {
            this.topic = topic;
            this.numbers = numbers;
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
        public int numbers_of_exams;
        public FinalExam(string topic, int numbers, int numbers_of_exams) : base(topic, numbers)
        {
            this.numbers_of_exams = numbers_of_exams;
        }
        public bool canReady()
        {
            if (numbers_of_exams < 5)
                return true;
            else
                return false;
        }
    }


    public class ForObject : Object
    {
        public override bool Equals(object obj)
        {
            if (obj==null)
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
            Test test1 = new Test("mathematic", 10);
            Exams exam1 = new Exams("biolagy", 15);
            FinalExam final_exam1 = new FinalExam("fisiks", 11, 6);
            final_exam1.Clone();
            ((Ialive)final_exam1).Clone();

            Exams exam2 = new Exams("chemistry", 20);
            FinalExam final_exam2 = exam2 as FinalExam;
            if(final_exam2==null)
            {
                Console.WriteLine("No corret conversion");
            }

            FinalExam final_exan3 = new FinalExam("logistic", 12, 4);
            Exams exam3 = final_exan3 as Exams;

            if(exam3==null)
            {
                Console.WriteLine("No corret conversion");
            }
            else
                Console.WriteLine("Corret conversion");

            Console.WriteLine("test1 is Test " + (test1 is Test));
            Console.WriteLine("test1 is Exam " + (test1 is Exams));
            Console.WriteLine("exam1 is Test "+ (exam1 is Test));
            Console.WriteLine("exam1 is Exam " + (exam1 is Exams));

            Console.WriteLine(exam2.ToString());

            Printer printer = new Printer();
            printer.IAmPrinting(final_exan3);

            Console.WriteLine("----------------------Array-----------------------");
            Question[] questions = new Question[] { test1, exam1, final_exam1 };
            for(int i=0; i<questions.Length; i++)
            {
                printer.IAmPrinting(questions[i]);
                Console.WriteLine("--------------------------------------");
            }
        }
    }
}
