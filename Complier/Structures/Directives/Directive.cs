using Complier.Structures.Instructions;

namespace Complier.Structures.Directives
{
    //伪指令
    public class Directive : Instruction
    {
        public Directive(int code_length, int line) : base(code_length, line)
        {
        }
        public override string ToString()
        {
            return "{Directive:{" + $"Line={Line}" + "} }";
        }
    }
}
