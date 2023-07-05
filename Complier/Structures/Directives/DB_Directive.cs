using Complier.CodeAnalyzer;
using Complier.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Complier.Structures.Directives
{
    public class DB_Directive : Directive
    {
        public IEnumerable<Token> NumberTokens { get; set; }
        public DB_Directive(IEnumerable<Token> number_tokens, int line) : base(line)
        {
            NumberTokens = number_tokens;
        }
        public override string ToString()
        {
            return "{DB_Directive:{" + $" HexCode= {GetHexCode().GetString()}, Line={Line}" + "} }";
        }

        public override byte[] GetHexCode()
        {
            return NumberTokens.Select(e => e.NumberTokenToBytes()[0]).ToArray();
        }
    }
}
