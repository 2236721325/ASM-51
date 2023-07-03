using Complier.Structures.Instructions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Complier.Structures
{
    //一页代码
    public class Block  
    {
        public IEnumerable<Instruction> Instructions { get; set; }

        public Block(IEnumerable<Instruction> instructions)
        {
            Instructions = instructions;
        }
    }
}
