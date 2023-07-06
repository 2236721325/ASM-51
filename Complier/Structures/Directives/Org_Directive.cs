using Complier.CodeAnalyzer;

namespace Complier.Structures.Directives
{
    public class Org_Directive : Directive
    {
        public Token AddressToken { get; set; }
        public Org_Directive(Token address_token, int line) : base(0, line)
        {
            AddressToken = address_token;
        }

        public override string ToString()
        {
            return "{Org_Directive:{" + $"Mnemonic={{ORG address}} , AddressValue={AddressToken.Value} ,Line={Line}" + "} }";
        }
    }
}
