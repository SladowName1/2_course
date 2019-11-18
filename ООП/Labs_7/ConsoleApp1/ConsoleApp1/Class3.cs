using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_6;

namespace ConsoleApp1
{

    class WrongIdValue : Exception
    {
        int Value { get; set; }
        public WrongIdValue(string message, int value):base(message)
        {
            Value = value;
        }
    }

    class WrongNumbersValue : Exception
    {
        int Value { get; set; }
        public WrongNumbersValue(string message, int value) : base(message)
        {
            Value = value;
        }
    }
    class IsNotTopic:ArgumentException
    {
        string Value { get; set; }
        public IsNotTopic(string message, string value):base(message)
        {
            Value = value;
        }
    }
}
