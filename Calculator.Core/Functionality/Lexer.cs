using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Calculator.Core.Functionality
{
    public class Lexer
    {
        private readonly Tokenlist _tokenList;
        private string _code;
        private List<string> _tokens;
        private int _position;

        public string[] Tokens => _tokens.Where(str => !string.IsNullOrWhiteSpace(str)).ToArray();

        public Lexer(string code)
        {
            _code = code;
            _position = 0;
            _tokens = new List<string>();
            _tokenList = new Tokenlist();

            LexicalAnalisys();
        }

        private void LexicalAnalisys()
        {
            while (NextToken()) { }
        }

        private bool NextToken()
        {
            if (_position >= _code.Length) return false;
            foreach (var item in _tokenList.TokenPatterns)
            {
                var result = Regex.Match(_code.Substring(_position), "^" + item).Value;

                if (!string.IsNullOrEmpty(result))
                {
                    Console.WriteLine(_position);
                    Console.WriteLine(item);
                    Console.WriteLine(result);

                    _tokens.Add(result);
                    _position += result.Length;
                    Console.WriteLine("Substring:\t|" + _code.Substring(_position));
                    Console.WriteLine("===============================================================================\n");
                    return true;
                }
            }
            throw new NotImplementedException($"Ошибка на позиции: {_position}");//разберись ибо исключение ищ не вызывается
        }

    }
}
