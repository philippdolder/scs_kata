using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDailyKata
{
    public enum TokenType
    {
        Number,
        Operator
    }

    public abstract class Token
    {
        public abstract TokenType Type { get; }
    }

    public class Number : Token
    {
        public Number(int value)
        {
            this.Value = value;
        }

        public int Value { get;  }

        public override TokenType Type => TokenType.Number;
    }

    public class Operator : Token
    {
        public Operator(char value)
        {
            this.Value = value;
        }

        public char Value { get; }

        public override TokenType Type => TokenType.Operator;
    }
}
