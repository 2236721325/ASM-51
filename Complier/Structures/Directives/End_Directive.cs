namespace Complier.Structures.Directives
{
    public class End_Directive : Directive
    {
        public End_Directive(int line) : base(0, line)
        {
        }
        public override string ToString()
        {
            return "{End_Directive:{" + $"Mnemonic={{END}} ,Line={Line}" + "} }";
        }
    }
}
