using Complier.CodeAnalyzer;

namespace Complier.Structures.Directives
{
    public class Label_Directive : Directive
    {
        public Token Identifier { get; set; }
        public Label_Directive(Token identifier, int line) : base(line)
        {
            Identifier = identifier;
        }

        public override string ToString()
        {
            return "{Label_Directive:{" + $"Mnemonic={{Label:}}, Identifier={Identifier.Value},Line={Line}" + "} }";
        }
    }
}
