using Complier.Structures.Instructions;

namespace Complier.Structures
{
    public class InstructionWrap
    {
        public Instruction Instruction { get; set; }
        public int Address { get; set; }
        public InstructionWrap(int address,Instruction instruction) 
        {
            Address = address;
            Instruction = instruction;
        }
    }
}
