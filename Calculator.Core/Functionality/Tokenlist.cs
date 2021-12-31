using System.Collections.Generic;

namespace Calculator.Core.Functionality
{
    public class Tokenlist
    {
        private List<string> _tokenPatterns;

        public Tokenlist()
        {
            _tokenPatterns = new List<string>
            {
                @"(\s|\n|\t|\r)",
                @"(\d*\,*\d*|\d*)",
                @"(\+|\-|\/|\*)",
                @"(\(|\))"
            };
        }

        public List<string> TokenPatterns => _tokenPatterns;

    }
}
