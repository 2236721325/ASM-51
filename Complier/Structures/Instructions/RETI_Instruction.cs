using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
        public class RETI_Instruction : Instruction
        {
            public RETI_Instruction(int line) : base(1, line)
            {
            }
            public override Byte[] GetHexCode()
            {
                return new byte[] { 0x32 };
            }
            public override string ToString()
            {
                return "{RETI_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
            }
        }

    }



