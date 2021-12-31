using Calculator.Core.Functionality;

namespace Calculator.Core
{
    public class CalcFacade : IFacade
    {
        private Lexer _lexer;
        private Parser _parser;

        public string Code { get; set; }

        public double Calculate()
        {
            if (Code != null)
            {
                _lexer = new Lexer(Code);
                _parser = new Parser(_lexer.Tokens);
                return _parser.Parse();
            }

            return -1;
        }
    }
}
