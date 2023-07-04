using System;

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
        /// <summary>
        /// will return null;
        /// </summary>
        /// <returns></returns>
        public virtual Byte[] GetHexCode()
        {
            return null;
        }

        public override string ToString()
        {
            return "{Instruction:{" + $"Line={Line},Code=null " + "} }";
        }
    }


}
