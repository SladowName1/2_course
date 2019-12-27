using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serializ
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

    [Serializable]
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

        [Serializable]
        public class Test : Question, Ialive
        {
            public Test()
            { }
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

    }



