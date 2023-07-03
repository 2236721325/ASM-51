using Complier.CodeAnalyzer;

namespace Complier.Structures.Instructions
{
    //指令
    public  class Instruction
    {
        public int Line { get; set; }

        public Instruction(int line)
        {
            Line = line;
        }
        public virtual string GetHexCode()
        {
            return string.Empty;
        }
    }

    public class Nop_Instruction : Instruction
    {
        public Nop_Instruction(int line) : base(line)
        {
        }
        public override string GetHexCode()
        {
            return "00";
        }
    }


    /// <summary>
    /// ADD,A,Rn                    0
    /// ADD A,direct                1
    /// Add A,@Ri                   2
    /// Add A,#data                 3
    /// </summary>
    public class Add_Instruction : Instruction
    {

        public PrefixStructure Second { get; set; }

        public ushort Type; 
        public Add_Instruction(PrefixStructure second, ushort type,int line) : base(line)
        {
            Second = second;
            Type = type;
        }
    }


}
