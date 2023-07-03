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
        public override string ToString()
        {
            return "{Directive:{" + $"Line={Line}" + "} }";
        }
    }

    public class Label_Directive : Directive
    {
        public Token Identifier { get; set; }
        public Label_Directive(Token identifier, int line) : base(line)
        {
            Identifier = identifier;
        }

        public override string ToString()
        {
            return "{Label_Directive:{" + $"Identifier={Identifier.Value},Line={Line}" + "} }";
        }
    }

    public class End_Directive : Directive
    {
        public End_Directive(int line) : base(line)
        {
        }
        public override string ToString()
        {
            return "{End_Directive:{" + $"Line={Line}" + "} }";
        }
    }

    public class Org_Directive : Directive
    {
        public Token AddressToken { get; set; }
        public Org_Directive(Token address_token, int line) : base(line)
        {
            AddressToken = address_token;
        }

        public override string ToString()
        {
            return "{Org_Directive:{" + $"AddressValue={AddressToken.Value} ,Line={Line}" + "} }";
        }
    }
}
