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
}
