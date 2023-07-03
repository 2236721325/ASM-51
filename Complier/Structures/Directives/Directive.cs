using Complier.CodeAnalyzer;
using Complier.Structures.Instructions;

namespace Complier.Structures.Directives
{
    //伪指令
    public class Directive : Instruction
    {
        public Directive(int line) : base(line)
        {
        }
    }

    public class Label_Directive : Directive
    {
        public Token Identifier { get; set; }
        public Label_Directive(Token identifier, int line) : base(line)
        {
            Identifier = identifier;
        }
    }

    public class End_Directive : Directive
    {
        public End_Directive(int line) : base(line)
        {
        }
    }

    public class Org_Directive : Directive
    {
        public Token AddressToken { get; set; }
        public Org_Directive(Token address_token, int line) : base(line)
        {
            AddressToken = address_token;
        }
    }
}
