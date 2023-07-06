using Complier.Helpers;
using System;

namespace Complier.Structures.Instructions
{
        public class RET_Instruction : Instruction
        {
            public RET_Instruction(int line) : base(1, line)
            {
            }
            public override Byte[] GetHexCode()
            {
                return new byte[] { 0x22 };
            }
            public override string ToString()
            {
                return "{RET_Instruction:{" + $"HexCode={GetHexCode().GetString()} ,Line={Line}" + "} }";
            }
        }

    }



