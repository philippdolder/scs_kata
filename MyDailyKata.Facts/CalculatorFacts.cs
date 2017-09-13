using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace MyDailyKata
{
    public class CalculatorFacts
    {
        private readonly Calculator _testee;
        // TODO addition operation returns sum of operands
        // TODO subtraction operation returns (first - second) operand
        public CalculatorFacts()
        {
            this._testee = new Calculator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ReturnsZero_WhenInputEmpty(string empty)
        {
            int result = this._testee.Calculate(empty);

            result.Should().Be(0);
        }

        [Fact]
        public void ReturnsNumber()
        {
            const string NumberAsInput = "5";
            const int Number = 5;

            int result = this._testee.Calculate(NumberAsInput);

            result.Should().Be(Number);
        }

        [Theory]
        [InlineData("42+2", 44)]
        [InlineData("1+2+3", 6)]
        public void ReturnsSumOfOperands_WhenAdding(string operation, int sum)
        {
            int result = this._testee.Calculate(operation);

            result.Should().Be(sum);
        }

        [Fact]
        public void ReturnsDifferenceBetweenMinuendAndSubtrahend()
        {
            int result = this._testee.Calculate("42-2");

            result.Should().Be(40);
        }
    }

    public class Calculator
    {
        private readonly Parser _parser;

        public Calculator()
        {
            this._parser = new Parser();
        }
        public int Calculate(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            return this._parser.Parse(input).Evaluate();
        }

        private class Parser
        {
            public Token Parse(string expression)
            {
                var operands = expression.Split('+');
                if (operands.Length == 1)
                {
                    return new Number(Convert.ToInt32(operands[0]));
                }

                

                throw new Exception();
            }
        }

        public abstract class Token
        {
            public abstract int Evaluate();
        }

        public class Number : Token
        {
            private readonly int _value;

            public Number(int value)
            {
                this._value = value;
            }

            public override int Evaluate()
            {
                return this._value;
            }
        }

        public class AdditionOperator : Token
        {
            private readonly Token _leftOperand;
            private readonly Token _rightOperand;

            public AdditionOperator(Token leftOperand, Token rightOperand)
            {
                this._leftOperand = leftOperand;
                this._rightOperand = rightOperand;
            }

            public override int Evaluate()
            {
                return this._leftOperand.Evaluate() + this._rightOperand.Evaluate();
            }
        }

        public class SubtractionOperator : Token
        {
            private readonly Token _leftOperand;
            private readonly Token _rightOperand;

            public SubtractionOperator(Token leftOperand, Token rightOperand)
            {
                this._leftOperand = leftOperand;
                this._rightOperand = rightOperand;
            }

            public override int Evaluate()
            {
                return this._leftOperand.Evaluate() - this._rightOperand.Evaluate();
            }
        }
    }
}