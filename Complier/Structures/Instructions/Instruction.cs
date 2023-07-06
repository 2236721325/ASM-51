using System;

namespace Complier.Structures.Instructions
{
    //指令
    public  class Instruction
    {
        public int Line { get; set; }

        public Instruction(int code_length,int line)
        {
            Line = line;
            HexCodeLength = code_length;
        }
        /// <summary>
        /// will return null;
        /// </summary>
        /// <returns></returns>
        public virtual Byte[] GetHexCode()
        {
            return null;
        }

        public int HexCodeLength { get; set; }



        public override string ToString()
        {
            return "{Instruction:{" + $"Line={Line},Code=null " + "} }";
        }
    }


}
