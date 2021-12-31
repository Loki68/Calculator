using System;

namespace Calculator.Core.Functionality
{
    public class Parser
    {
        private readonly string[] _tokens;
        private int _position;

        public Parser(string[] tokens)
        {
            _tokens = tokens;
            _position = 0;

        }

        public double Parse()
        {
            double result = Addy();
            Console.WriteLine(_position);
            if (_position != _tokens.Length)
            {
                throw new IndexOutOfRangeException();
            }

            return result;
        }

        //T+-T+-...+-T
        private double Addy()
        {
            double leftToken = Multy();

            while (_position < _tokens.Length)
            {
                string operationToken = _tokens[_position];

                if (!operationToken.Equals("+") && !operationToken.Equals("-"))
                {
                    break;
                }
                else
                {
                    _position++;
                }

                double rightToken = Multy();

                if (operationToken.Equals("+"))
                {
                    leftToken += rightToken;
                }
                else
                {
                    leftToken -= rightToken;
                }
            }

            return leftToken;
        }

        //M*/M*/..*/M
        private double Multy()
        {
            double leftToken = Elemy();

            while (_position < _tokens.Length)
            {
                string operationToken = _tokens[_position];

                if (!operationToken.Equals("*") && !operationToken.Equals("/"))
                {
                    break;
                }
                else
                {
                    _position++;
                }

                double rightToken = Elemy();

                switch (operationToken)
                {
                    case "*":
                        {
                            leftToken *= rightToken;

                            break;
                        }
                    case "/":
                        {
                            if (rightToken == 0)
                            {
                                throw new DivideByZeroException("Деление на нуль");
                            }

                            leftToken /= rightToken;

                            break;
                        }
                }
            }

            return leftToken;
        }

        private double Elemy()
        {
            string nextTokenValue = _tokens[_position];
            double result;
            if (nextTokenValue.Equals("("))
            {
                _position++;
                result = Addy();

                string closingBracket;
                if (_position < _tokens.Length)
                {
                    closingBracket = _tokens[_position];
                }
                else
                {
                    throw new NotImplementedException();
                }

                if (_position < _tokens.Length && closingBracket.Equals(")"))
                {
                    _position++;
                    return result;
                }

                throw new NotImplementedException();
            }

            _position++;

            return double.Parse(nextTokenValue);
        }
    }
}
