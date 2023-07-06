using Complier.CodeAnalyzer;

namespace Complier.Structures.Directives
{
    public class EQU_Directive : Directive
    {
        public Token NameToken { get; set; }
        public Token ValueToken { get; set; }
        public EQU_Directive(Token name_token,Token value_token, int line) : base(0,line)
        {
            NameToken = name_token;
            ValueToken = value_token;
        }

        public override string ToString()
        {
            return "{EQU_Directive:{" + $"Mnemonic={{ORG address}} , NameToken={NameToken.Value} , ValueToken= {ValueToken.Value}, Line={Line}" + "} }";
        }
    }
}
